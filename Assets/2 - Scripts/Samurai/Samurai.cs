using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Samurai : MonoBehaviour
{
    public Action OnJump;
    public Action OnAttack;
    

    [SerializeField] private InputController inputController;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 0.5f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackUpForce = 1f;

    public Rigidbody2D rb { get; private set; }

    public Inputs CurrentInput { get { return this.inputController.Inputs; } }
    public SamuraiState CurrentState { get; private set; }

    public SamuraiJump JumpingState { get; private set; }
    public SamuraiFall FallingState { get; private set; }
    public SamuraiAttack AttackingState { get; private set; }

    public float JumpCooldown { get; private set; }
    public float AttackCooldown { get; private set; }

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();

        JumpCooldown = 0f;
        AttackCooldown = 0f;

        this.JumpingState = new SamuraiJump(this);
        this.FallingState = new SamuraiFall(this);
        this.AttackingState = new SamuraiAttack(this);

        SetState(this.FallingState);
    }

    void Update()
    {
        this.CurrentState?.FrameUpdate();

        if (this.JumpCooldown > 0f) this.JumpCooldown -= Time.deltaTime;

        if (this.AttackCooldown > 0f) this.AttackCooldown -= Time.deltaTime;
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
}
