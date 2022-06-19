using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlatformTrigger : MonoBehaviour
{
    [SerializeField] private PlatformController level;
    [SerializeField] private string triggerTag;

    private void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == triggerTag)
        {
            level.GameController.SpawnController.NextPlatform();
            Debug.Log("Player entered trigger ================================================");
        }
    }
}
