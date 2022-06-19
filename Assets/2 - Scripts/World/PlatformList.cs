using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Platform {
    public GameObject prefab;
    public float spawnChance;
}

[System.Serializable, CreateAssetMenu(fileName = "PlatformList", menuName = "PlatformList")]
public class PlatformList : ScriptableObject
{
    [SerializeField] private List<Platform> platforms = new List<Platform>();

    public Platform GetRandomPlatform()
    {
        float totalChance = 0;
        foreach (Platform platform in platforms)
            totalChance += platform.spawnChance;

        float randomPoint = Random.value * totalChance;

        float runningTotal = 0;
        foreach (Platform platform in platforms)
        {
            runningTotal += platform.spawnChance;
            if (randomPoint < runningTotal)
                return platform;
        }

        return null;
    }

    
}


