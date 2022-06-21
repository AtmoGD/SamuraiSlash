using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlatformTrigger : MonoBehaviour
{
    [SerializeField] private PlatformController level;
    [SerializeField] private string triggerTag;

    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.tag == triggerTag)
        {
            triggered = true;
            level.GameController.SpawnController.NextPlatform();
        }
    }
}
