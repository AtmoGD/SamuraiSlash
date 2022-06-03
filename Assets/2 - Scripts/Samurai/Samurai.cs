using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{
    [SerializeField] private InputController inputController;

    public Inputs CurrentInput { get { return this.inputController.Inputs; }}

    public SamuraiState CurrentState { get; private set; }

    public SamuraiJump JumpingState { get; private set; }
    public SamuraiFalling FallingState { get; private set; }

    void Start()
    {
        JumpingState = new SamuraiJump(this);
        FallingState = new SamuraiFalling(this);

        SetState(this.FallingState);
    }

    void Update()
    {
        this.CurrentState?.FrameUpdate();
    }

    private void FixedUpdate() {
        this.CurrentState?.PhysicsUpdate();
    }

    public void SetState(SamuraiState state)
    {
        CurrentState?.Exit();
        CurrentState = state;
        CurrentState?.Enter();
    }
}
