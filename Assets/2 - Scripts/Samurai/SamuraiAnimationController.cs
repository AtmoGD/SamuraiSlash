using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Samurai))]
public class SamuraiAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Samurai samurai;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        samurai = GetComponent<Samurai>();
    }

    private void Start() {
        samurai.OnAttack += OnAttack;
    }
    
    private void OnAttack() {
        animator.SetTrigger("Attack");
    }

    private void Update() {
        animator.SetFloat("Speed", samurai.rb.velocity.y);
    }
}
