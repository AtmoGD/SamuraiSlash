using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    [SerializeField] private GameController gameController;
    public GameController GameController { get { return gameController; } }

    [SerializeField] private float maxDistance = 10f;
    public float MaxDistance { get { return maxDistance; } }

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    private void Update()
    {
        if (-transform.position.x > maxDistance)
        {
            DestroyImmediate(gameObject);
        }
    }
}
