using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Samurai : MonoBehaviour, IAttackable
{
    public Action OnJump;
    public Action OnAttack;
    public Action OnDash;
    public Action OnDashEnd;
    public Action OnDeath;
    public Action<int> OnUpdateLife;

    [SerializeField] private float score = 0f;
    public float Score { get { return score; } }

    [SerializeField] private GameController gameController;
    public GameController GameController { get { return gameController; } }
    [SerializeField] private InputController inputController;

    [SerializeField] private int life = 3;
    public int Life { get { return life; } }

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 0.5f;

    [SerializeField] public Transform attackCkeck;
    [SerializeField] private int attackStrenghtSmall = 1;
    [SerializeField] private int attackStrenghtBig = 2;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackUpForce = 1f;

    [SerializeField] private float getHitSpeed = 0.6f;
    public float GetHitSpeed { get { return getHitSpeed; } }
    [SerializeField] private float getHitTime = 0.2f;
    public float GetHitTime { get { return getHitTime; } }

    [SerializeField] private float dashSpeed = 10f;
    public float DashSpeed { get { return dashSpeed; } }
    [SerializeField] private float dashCooldown = 0.5f;

    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }

    public Inputs CurrentInput { get { return inputController.Inputs; } }
    public SamuraiState CurrentState { get; private set; }

    public SamuraiJump JumpingState { get; private set; }
    public SamuraiFall FallingState { get; private set; }
    public SamuraiAttack AttackingState { get; private set; }
    public SamuraiDash DashState { get; private set; }
    public SamuraiGetHit GetHitState { get; private set; }

    public float JumpCooldown { get; private set; }
    public float AttackCooldown { get; private set; }
    public float DashCooldown { get; private set; }

    private float oldWorldSpeedMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        JumpCooldown = 0f;
        AttackCooldown = 0f;
        DashCooldown = 0f;

        JumpingState = new SamuraiJump(this);
        FallingState = new SamuraiFall(this);
        AttackingState = new SamuraiAttack(this);
        DashState = new SamuraiDash(this);
        GetHitState = new SamuraiGetHit(this);

        SetState(FallingState);
    }

    void Update()
    {
        CurrentState?.FrameUpdate();

        score += Time.deltaTime * gameController.WorldSpeedMultiplier;

        if (JumpCooldown > 0f) JumpCooldown -= Time.deltaTime;

        if (AttackCooldown > 0f) AttackCooldown -= Time.deltaTime;

        if (DashCooldown > 0f) DashCooldown -= Time.deltaTime;

        animator.SetFloat("Speed", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }
    public void SetState(SamuraiState _state)
    {
        CurrentState?.Exit();
        CurrentState = _state;
        CurrentState?.Enter();
    }

    public void AddScore(float _score)
    {
        this.score += _score;
    }

    public void TakeDamage(int _damage)
    {
        life -= _damage;
        SetState(GetHitState);
        OnUpdateLife?.Invoke(Life);
    }

    public void TakeDamage(int _damage, Samurai _attacker)
    {
    }

    public void Jump()
    {
        if (JumpCooldown > 0f) return;

        JumpCooldown = jumpCooldown;

        rb.velocity = Vector2.up * jumpForce;

        inputController.UseJump();

        OnJump?.Invoke();
    }

    public void Attack()
    {
        if (AttackCooldown > 0f) return;

        AttackCooldown = attackCooldown;

        rb.velocity = Vector2.up * attackUpForce;

        animator.SetTrigger("Attack");

        inputController.UseAttack();

        OnAttack?.Invoke();
    }

    public void CheckAttack()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackCkeck.position, attackRange, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            IAttackable attackable = hit.collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                if (attackable is not Samurai)
                    attackable.TakeDamage(attackStrenghtSmall, this);
            }
        }
    }

    public void CheckDash()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackCkeck.position, attackRange, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            IAttackable attackable = hit.collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                if (attackable is not Samurai)
                    attackable.TakeDamage(attackStrenghtBig, this);
            }
        }
    }

    public void Dash()
    {
        if (DashCooldown > 0f) return;

        DashCooldown = dashCooldown;

        animator.SetBool("Dashing", true);

        inputController.UseDash();
    }

    public void StopDash()
    {
        animator.SetBool("Dashing", false);
    }

    public void Die()
    {
        gameController.EndGame();
        OnDeath?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        Collectable collect = _other.GetComponent<Collectable>();

        if (collect)
        {
            score += collect.ScoreAmount;
            collect.Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCkeck.position, attackRange);
    }
}
