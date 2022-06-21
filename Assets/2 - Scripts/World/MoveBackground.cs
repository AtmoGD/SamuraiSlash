using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    public float speed;
    private float x;
    public bool loop;
    public float dest;
    public float startPoint;

    void Update()
    {
        x = transform.position.x;

        if (loop & x <= dest)
            x = startPoint;

        x += speed * gameController.WorldSpeedMultiplier * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }

    public void SetGameController(GameController _gameController)
    {
        gameController = _gameController;
    }
}
