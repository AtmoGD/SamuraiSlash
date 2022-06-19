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
        x += speed * gameController.WorldSpeedMultiplier * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (x <= dest)
        {
            if (loop)
            {
                x = startPoint;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetGameController(GameController gameController)
    {
        this.gameController = gameController;
    }
}
