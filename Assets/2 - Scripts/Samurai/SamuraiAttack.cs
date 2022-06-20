using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiAttack : SamuraiState
{
    private float attackTimer = 0f;
    public SamuraiAttack(Samurai _samurai) : base(_samurai) { }

    public override void Enter() {
        attackTimer = 0f;

        this.samurai.Attack();

        this.samurai.SetState(this.samurai.FallingState);
    }

    public override void FrameUpdate() { }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}
