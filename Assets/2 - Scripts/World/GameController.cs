using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnController spawnController;
    public SpawnController SpawnController { get { return spawnController; } }

    [SerializeField] private float worldSpeedMultiplier = 1f;
    public float WorldSpeedMultiplier{ get { return worldSpeedMultiplier; } }

    public void SetWorldSpeed(float speed)
    {
        worldSpeedMultiplier = speed;
    }

    //Get spawn controller
}
