using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiDash : SamuraiState
{
    public SamuraiDash(Samurai _samurai) : base(_samurai) { }

    private float dashTimer = 0f;

    private Vector3 startPos;
    // private bool isDashing = false;

    public override void Enter()
    {
        // if(!this.samurai.CanDash)
        // {
        //     this.samurai.SetState(this.samurai.FallingState);
        //     return;
        // }

        this.samurai.Dash();

        this.samurai.GameController.CustomSpeedModifier.Add(this.samurai.DashSpeed);

        // isDashing = true;

        this.startPos = this.samurai.transform.position;

        dashTimer = samurai.DashCooldown;
    }

    public override void FrameUpdate()
    {
        if (samurai.DashCooldown < 0f)
            this.samurai.SetState(this.samurai.FallingState);
    }

    public override void PhysicsUpdate()
    {
        // RaycastHit2D hit = Physics2D.Linecast(this.samurai.dashCheck.position, this.samurai.dashCheck.position + Vector3.right * this.samurai.DashCheckDistance);

        // if (hit.collider != null && hit.collider.tag.Equals("Platform"))
        // {
        //     this.samurai.SetState(this.samurai.FallingState);
        // }
        // RaycastHit2D[] hits = Physics2D.LinecastAll(this.samurai.dashCheck.position, this.samurai.dashCheck.position + Vector3.right * this.samurai.DashDistance);
        // foreach (RaycastHit2D hit in hits)
        // {
        //     if (hit.collider.gameObject.tag == "Platform")
        //     {
        //         Debug.Log("Can NOT dash");
        //         this.samurai.SetState(this.samurai.FallingState);
        //     }
        // }

        this.samurai.transform.position = startPos;
    }

    public override void Exit()
    {
        // if (!isDashing) return;

        this.samurai.StopDash();

        this.samurai.GameController.CustomSpeedModifier.Remove(this.samurai.DashSpeed);
    }
}
