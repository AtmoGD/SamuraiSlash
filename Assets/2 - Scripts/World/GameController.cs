using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnController spawnController;
    public SpawnController SpawnController { get { return spawnController; } }

    [SerializeField] private float worldSpeedMultiplier = 1f;
    public float WorldSpeedMultiplier { 
        get { 
            float resultMultiplier = worldSpeedMultiplier * ScoreMultiplier;

            foreach(float multilplier in CustomSpeedModifier)
                resultMultiplier *= multilplier;
                
            return resultMultiplier; 
        }
    }
    [SerializeField] private float scoreMultiplier = 0.01f;
    public float ScoreMultiplier { get { return 1 + (Samurai.Score * scoreMultiplier); } }

    public List<float> CustomSpeedModifier { get; set; }

    [SerializeField] private Samurai player;
    public Samurai Samurai { get { return player; } }

    private void Awake() {
        CustomSpeedModifier = new List<float>();
    }

    public void SetWorldSpeed(float speed)
    {
        worldSpeedMultiplier = speed;
    }

    private void Update()
    {

    }
}
