using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : InputController
{
    bool dashReleased = true;
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) Inputs.jump = true;
        if (context.canceled) Inputs.jump = false;
    }

    public void OnJump() {
        Inputs.jump = true;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started) Inputs.attack = true;
        if (context.canceled) Inputs.attack = false;
    }

    public void OnAttack() {
        Inputs.attack = true;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (dashReleased)
        {
            if (context.started)
            {
                Inputs.dash = true;
                dashReleased = false;
            }
        }
        if (context.canceled)
        {
            Inputs.dash = false;
            dashReleased = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started) Inputs.pause = true;
        if (context.canceled) Inputs.pause = false;
    }
}
