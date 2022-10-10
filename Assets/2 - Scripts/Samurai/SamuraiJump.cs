using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiJump : SamuraiState
{
    public SamuraiJump(Samurai _samurai) : base(_samurai) { }

    public override void Enter()
    {
        samurai.Jump();

        samurai.PlayRandomSound(samurai.jumpSoundNames);

        samurai.SetState(samurai.FallingState);
    }

    public override void FrameUpdate() { }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}