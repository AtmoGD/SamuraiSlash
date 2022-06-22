using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable
{
    [SerializeField] private Animator anim;
    [SerializeField] private float scoreAmount = 50;
    public float ScoreAmount { get { return scoreAmount; } }
    [SerializeField] private float life = 1;
    public float Life { get { return life; } }
    [SerializeField] private int damage = 1;
    public int Damage { get { return damage; } }

    private float lifeLeft = 1;
    public float LifeLeft { get { return lifeLeft; } }

    bool died = false;

    public void TakeDamage(int _amount)
    {
        lifeLeft -= _amount;

        if (lifeLeft <= 0)
            Die();
    }

    public void TakeDamage(int _amount, Samurai _samurai)
    {
        lifeLeft -= _amount;

        if (lifeLeft <= 0)
        {
            _samurai.AddScore(scoreAmount);
            Die();
        }
    }

    public void Die()
    {
        if (died) return;

        died = true;
        anim.SetTrigger("Die");
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (died) return;

        IAttackable attackable = _other.gameObject.GetComponent<IAttackable>();
        if (attackable != null)
        {
            attackable.TakeDamage(Damage);
            Die();
        }
    }
}
