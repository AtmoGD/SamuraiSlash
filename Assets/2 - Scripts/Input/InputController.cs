using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Inputs Inputs { get; protected set; }
    private void Awake()
    {
        Inputs = new Inputs();
    }

    public void UseJump()
    {
        Inputs.jump = false;
    }

    public void UseAttack()
    {
        Inputs.attack = false;
    }
}
