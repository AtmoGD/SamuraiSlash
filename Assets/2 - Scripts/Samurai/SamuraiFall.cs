using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiFall : SamuraiState
{
    public SamuraiFall(Samurai _samurai) : base(_samurai) { }

    public override void Enter() { }

    public override void FrameUpdate()
    {
        if (samurai.CurrentInput.attack && samurai.AttackCooldown <= 0f)
            samurai.SetState(samurai.AttackingState);

        if (samurai.CurrentInput.jump && samurai.JumpCooldown <= 0f)
            samurai.SetState(samurai.JumpingState);

        if (samurai.CurrentInput.dash && samurai.DashCooldown <= 0f)
            samurai.SetState(samurai.DashState);
    }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}
