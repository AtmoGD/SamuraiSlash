using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float scoreAmount = 50;
    public float ScoreAmount { get { return scoreAmount; } }
    [SerializeField] private float life = 1;
    public float Life { get { return life; } }

    private float lifeLeft = 1;
    public float LifeLeft { get { return lifeLeft; } }

    bool died = false;

    public void TakeDamage(int _amount) {
        lifeLeft -= _amount;

        if(lifeLeft <= 0)
            Die();
    }

    public void Die() {
        if(died) return;
        
        died = true;
        anim.SetTrigger("Die");
        Destroy(this.gameObject);
    }

    public void DestroyThis() {
        Destroy(this.gameObject);
    }
}
