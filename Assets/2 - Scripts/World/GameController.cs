using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Action OnGameOver;

    [SerializeField] private SpawnController spawnController;
    public SpawnController SpawnController { get { return spawnController; } }

    [SerializeField] private float worldSpeedMultiplier = 1f;
    public float WorldSpeedMultiplier
    {
        get
        {
            float resultMultiplier = worldSpeedMultiplier * ScoreMultiplier;

            foreach (float multilplier in CustomSpeedModifier)
                resultMultiplier *= multilplier;

            return resultMultiplier;
        }
    }
    [SerializeField] private float scoreMultiplier = 0.01f;
    public float ScoreMultiplier { get { return 1 + (Samurai.Score * scoreMultiplier); } }

    [SerializeField] private float gameOverLerpSpeed = 0.01f;
    public float GameOverLerpSpeed { get { return gameOverLerpSpeed; } }

    public List<float> CustomSpeedModifier { get; set; }

    [SerializeField] private Samurai player;
    public Samurai Samurai { get { return player; } }

    private bool isGameOver = false;

    private void Awake()
    {
        CustomSpeedModifier = new List<float>();
        Time.timeScale = 1f;
    }

    public void SetWorldSpeed(float speed)
    {
        worldSpeedMultiplier = speed;
    }

    public void EndGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        OnGameOver?.Invoke();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (!isGameOver) return;

        Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, GameOverLerpSpeed);
    }
}
