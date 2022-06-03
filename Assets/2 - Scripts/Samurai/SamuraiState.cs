using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SamuraiState
{
    protected Samurai samurai { get; set; }
    public SamuraiState(Samurai _samurai) => this.samurai = _samurai;
    public abstract void Enter();
    public abstract void FrameUpdate();
    public abstract void PhysicsUpdate();
    public abstract void Exit();
}