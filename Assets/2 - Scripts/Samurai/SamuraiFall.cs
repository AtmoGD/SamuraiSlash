using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiFall : SamuraiState
{
    public SamuraiFall(Samurai _samurai) : base(_samurai) { }

    public override void Enter() { }

    public override void FrameUpdate()
    {
        if(this.samurai.CurrentInput.attack && this.samurai.AttackCooldown <= 0f)
            this.samurai.SetState(this.samurai.AttackingState);

        if (this.samurai.CurrentInput.jump && this.samurai.JumpCooldown <= 0f)
            samurai.SetState(samurai.JumpingState);

        if (this.samurai.CurrentInput.dash && this.samurai.DashCooldown <= 0f)
            samurai.SetState(samurai.DashState);
    }

    public override void PhysicsUpdate() { }

    public override void Exit() { }
}
