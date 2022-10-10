using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ReverseGravity : MonoBehaviour
{
    [SerializeField] private bool ReverseGravityOnStart = false;
    void Start()
    {
        if (ReverseGravityOnStart)
            ReverseGravityScale();
    }

    public void ReverseGravityScale()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }
}
