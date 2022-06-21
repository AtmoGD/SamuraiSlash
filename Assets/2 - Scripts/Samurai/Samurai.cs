using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Samurai : MonoBehaviour
{
    public Action OnJump;
    public Action OnAttack;
    public Action OnDash;
    public Action OnDashEnd;

    [SerializeField] private float score = 0f;
    public float Score { get { return score; } }

    [SerializeField] private GameController gameController;
    public GameController GameController { get { return gameController; } }
    [SerializeField] private InputController inputController;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 0.5f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackUpForce = 1f;
    [SerializeField] private float dashSpeed = 10f;
    public float DashSpeed { get { return dashSpeed; } }
    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float dashCheckDistance = 10f;
    public float DashCheckDistance { get { return dashCheckDistance; } }
    [SerializeField] public Transform dashCheck;

    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }

    public Inputs CurrentInput { get { return this.inputController.Inputs; } }
    public SamuraiState CurrentState { get; private set; }

    public SamuraiJump JumpingState { get; private set; }
    public SamuraiFall FallingState { get; private set; }
    public SamuraiAttack AttackingState { get; private set; }
    public SamuraiDash DashState { get; private set; }

    public float JumpCooldown { get; private set; }
    public float AttackCooldown { get; private set; }
    public float DashCooldown { get; private set; }

    private float oldWorldSpeedMultiplier;

    // public bool CanDash {
    //     get {
    //         // Physics2D.LinecastAll
    //         RaycastHit2D[] hits = Physics2D.LinecastAll(this.dashCheck.position, Vector2.right * this.dashDistance);
    //         foreach (RaycastHit2D hit in hits) {
    //             if (hit.collider.gameObject.tag == "Platform") {
    //                 print("Can NOT dash");
    //                 return false;
    //             }
    //         }

    //         return true;
    //     }
    // }

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        JumpCooldown = 0f;
        AttackCooldown = 0f;
        DashCooldown = 0f;

        this.JumpingState = new SamuraiJump(this);
        this.FallingState = new SamuraiFall(this);
        this.AttackingState = new SamuraiAttack(this);
        this.DashState = new SamuraiDash(this);

        SetState(this.FallingState);
    }

    void Update()
    {
        this.CurrentState?.FrameUpdate();

        score += Time.deltaTime * gameController.WorldSpeedMultiplier;

        if (this.JumpCooldown > 0f) this.JumpCooldown -= Time.deltaTime;

        if (this.AttackCooldown > 0f) this.AttackCooldown -= Time.deltaTime;

        if (this.DashCooldown > 0f) this.DashCooldown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        this.CurrentState?.PhysicsUpdate();
    }
    public void SetState(SamuraiState state)
    {
        this.CurrentState?.Exit();
        this.CurrentState = state;
        this.CurrentState?.Enter();
    }

    public void Jump()
    {
        if (this.JumpCooldown > 0f) return;

        this.JumpCooldown = this.jumpCooldown;

        this.rb.velocity = Vector2.up * this.jumpForce;

        this.inputController.UseJump();

        this.OnJump?.Invoke();
    }

    public void Attack()
    {
        if (this.AttackCooldown > 0f) return;

        this.AttackCooldown = this.attackCooldown;

        this.rb.velocity = Vector2.up * this.attackUpForce;

        this.inputController.UseAttack();

        this.OnAttack?.Invoke();
    }

    public void Dash()
    {
        if (this.DashCooldown > 0f) return;

        this.DashCooldown = this.dashCooldown;

        // this.oldWorldSpeedMultiplier = this.gameController.WorldSpeedMultiplier;

        // float speed = this.gameController.WorldSpeedMultiplier * this.dashSpeed;

        this.animator.SetBool("Dashing", true);

        this.inputController.UseDash();

        // this.gameController.SetWorldSpeed(speed);
    }

    public void StopDash()
    {
        // this.gameController.SetWorldSpeed(this.oldWorldSpeedMultiplier);

        this.animator.SetBool("Dashing", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectable collect = other.GetComponent<Collectable>();

        if (collect)
        {
            score += collect.ScoreAmount;
            collect.Die();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(dashCheck.position, Vector3.right * DashCheckDistance);
    }
}
