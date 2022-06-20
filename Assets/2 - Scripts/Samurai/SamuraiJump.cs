using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiJump : SamuraiState
{
    public SamuraiJump(Samurai _samurai) : base(_samurai) { }

    public override void Enter() {
        Debug.Log("Entering Jumping State");
        this.samurai.Jump();

        this.samurai.SetState(this.samurai.FallingState);
    }

    public override void FrameUpdate() { }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}