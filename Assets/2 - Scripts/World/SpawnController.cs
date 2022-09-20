using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private PlatformList platformList;
    [SerializeField] private float spawnTime = 1f;

    [SerializeField] private bool spawnOnStart;
    [SerializeField] private bool loop;
    [SerializeField] private Transform spawnParent;

    private void Start()
    {
        if (spawnOnStart)
            StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        if (loop)
            NextPlatform();
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnPlatforms());
    }

    public void NextPlatform()
    {
        Platform platform = platformList.GetRandomPlatform();
        if (platform != null && platform.prefab != null)
        {
            GameObject newPlatform;
            if (spawnParent != null)
                newPlatform = Instantiate(platform.prefab, spawnParent);
            else
                newPlatform = Instantiate(platform.prefab);
            // GameObject newPlatform = Instantiate(platform.prefab, transform.position, Quaternion.identity);

            MoveBackground moveBackground = newPlatform.GetComponent<MoveBackground>();
            if (moveBackground != null)
            {
                moveBackground.SetGameController(gameController);
                moveBackground.transform.localPosition = new Vector3(moveBackground.startPoint, moveBackground.transform.localPosition.y, moveBackground.transform.localPosition.z);
            }

            PlatformController platformController = newPlatform.GetComponent<PlatformController>();
            if (platformController != null)
            {
                platformController.Init(gameController);
            }
        }
    }
}
