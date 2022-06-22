using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float scoreAmount = 5;
    public float ScoreAmount { get { return scoreAmount; } }
    bool collected = false;
    public void Die()
    {
        if (collected) return;

        collected = true;
        anim.SetTrigger("Die");
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
