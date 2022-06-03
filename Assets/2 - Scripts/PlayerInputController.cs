using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : InputController
{
    public void OnJump(InputAction.CallbackContext context){
        if(context.performed) Inputs.jump = true;
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if(context.performed) Inputs.attack = true;
    }
}
