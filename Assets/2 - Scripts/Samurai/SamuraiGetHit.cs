using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiGetHit : SamuraiState
{
    private float hitTimer = 0f;
    public SamuraiGetHit(Samurai _samurai) : base(_samurai) { }

    public override void Enter()
    {
        if (samurai.Life <= 0) {
            samurai.Die();
            return;
        }

        samurai.animator.SetTrigger("Hit");

        hitTimer = samurai.GetHitTime;

        samurai.GameController.CustomSpeedModifier.Add(samurai.GetHitSpeed);
    }

    public override void FrameUpdate()
    {
        hitTimer -= Time.deltaTime;

        if (hitTimer < 0f)
            samurai.SetState(samurai.FallingState);
    }

    public override void PhysicsUpdate() { }

    public override void Exit()
    {
        samurai.GameController.CustomSpeedModifier.Remove(samurai.GetHitSpeed);
    }
}
