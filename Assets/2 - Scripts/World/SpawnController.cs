using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private PlatformList platformList;
    [SerializeField] private float spawnTime = 1f;

    [SerializeField] private bool spawn;
    [SerializeField] private Transform spawnParent;

    private void Start()
    {
        if (spawn)
            StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        if (spawn)
            SpawnPlatform();
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnPlatforms());
    }

    void SpawnPlatform()
    {
        Platform platform = platformList.GetRandomPlatform();
        if (platform != null && platform.prefab != null)
        {
            GameObject newPlatform = Instantiate(platform.prefab, transform.position, Quaternion.identity);
            // newPlatform.transform.parent = spawnParent;

            MoveBackground moveBackground = newPlatform.GetComponent<MoveBackground>();
            if (moveBackground != null) {
                moveBackground.SetGameController(gameController);
                moveBackground.transform.localPosition = new Vector3(moveBackground.startPoint, moveBackground.transform.localPosition.y, moveBackground.transform.localPosition.z);
            }
        }
    }
}
