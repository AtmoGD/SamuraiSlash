using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiAttack : SamuraiState
{
    private float attackTimer = 0f;
    public SamuraiAttack(Samurai _samurai) : base(_samurai) => Debug.Log("SamuraiAttack created");

    public override void Enter() {
        Debug.Log("Entering Attack State");
        attackTimer = 0f;

        this.samurai.Attack();

        this.samurai.SetState(this.samurai.FallingState);
    }

    public override void FrameUpdate() => Debug.Log("Updating Attack State");

    public override void PhysicsUpdate() => Debug.Log("Updating Attack State");

    public override void Exit() => Debug.Log("Exiting Attack State");
}
