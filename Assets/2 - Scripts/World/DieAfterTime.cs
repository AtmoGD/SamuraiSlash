using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    [SerializeField] private float time = 5f;

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
