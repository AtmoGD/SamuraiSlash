using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiAttack : SamuraiState
{
    public SamuraiAttack(Samurai _samurai) : base(_samurai) { }

    public override void Enter()
    {
        samurai.Attack();

        samurai.PlayRandomSound(samurai.attackSoundNames);

        samurai.SetState(samurai.FallingState);
    }

    public override void FrameUpdate() { }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}
