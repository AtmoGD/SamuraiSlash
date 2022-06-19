using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float worldSpeedMultiplier = 1f;
    public float WorldSpeedMultiplier { get { return worldSpeedMultiplier; } }
}
