using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : InputController
{
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) Inputs.jump = true;
        if (context.canceled) Inputs.jump = false;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) Inputs.attack = true;
        if (context.canceled) Inputs.attack = false;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) Inputs.dash = true;
        if (context.canceled) Inputs.dash = false;
    }
}
