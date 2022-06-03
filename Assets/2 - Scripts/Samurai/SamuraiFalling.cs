using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiFalling : SamuraiState
{
    public SamuraiFalling(Samurai _samurai) : base(_samurai) {
        Debug.Log("SamuraiFalling created");
        this.samurai = _samurai;
    }
    // public SamuraiFalling(Samurai _samurai) : base(_samurai) => Debug.Log("Samurai Falling created");
    public override void Enter() => Debug.Log("Entering Falling State");
    public override void FrameUpdate() {
        if(this.samurai.CurrentInput.jump)
            Debug.Log("Updating Falling State");
        // if(this.samurai.CurrentInput.jump)
        //     samurai.SetState(samurai.JumpingState);
    }
    public override void PhysicsUpdate() => Debug.Log("Updating Falling State");
    public override void Exit() => Debug.Log("Exiting Falling State");
}
