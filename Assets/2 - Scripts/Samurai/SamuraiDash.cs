using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiDash : SamuraiState
{
    public SamuraiDash(Samurai _samurai) : base(_samurai) { }

    private float dashTimer = 0f;

    private Vector3 startPos;

    public override void Enter()
    {
        samurai.Dash();

        samurai.GameController.CustomSpeedModifier.Add(samurai.DashSpeed);

        samurai.PlayRandomSound(samurai.dashSoundNames);

        startPos = samurai.transform.position;

        dashTimer = samurai.DashTime;
    }

    public override void FrameUpdate()
    {
        dashTimer -= Time.deltaTime;

        if (dashTimer < 0f)
            samurai.SetState(samurai.FallingState);
    }

    public override void PhysicsUpdate()
    {
        samurai.transform.position = startPos;

        samurai.CheckDash();
    }

    public override void Exit()
    {
        samurai.StopDash();

        samurai.GameController.CustomSpeedModifier.Remove(samurai.DashSpeed);
    }
}
