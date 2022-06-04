using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiFall : SamuraiState
{
    public SamuraiFall(Samurai _samurai) : base(_samurai) => Debug.Log("SamuraiFalling created");

    public override void Enter() => Debug.Log("Entering Falling State");

    public override void FrameUpdate()
    {
        if(this.samurai.CurrentInput.attack && this.samurai.AttackCooldown <= 0f)
            this.samurai.SetState(this.samurai.AttackingState);

        if (this.samurai.CurrentInput.jump && this.samurai.JumpCooldown <= 0f)
            samurai.SetState(samurai.JumpingState);
    }

    public override void PhysicsUpdate() => Debug.Log("Updating Falling State");

    public override void Exit() => Debug.Log("Exiting Falling State");
}
