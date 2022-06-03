using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiJump : SamuraiState
{
    public SamuraiJump(Samurai _samurai) : base(_samurai) => Debug.Log("SamuraiJump created");
    public override void Enter() => Debug.Log("Entering Jumping State");
    public override void FrameUpdate() => Debug.Log("Updating Jumping State");
    public override void PhysicsUpdate() => Debug.Log("Updating Jumping State");
    public override void Exit() => Debug.Log("Exiting Jumping State");
}