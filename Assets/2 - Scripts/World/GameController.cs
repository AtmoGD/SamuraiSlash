using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public Action OnGameOver;

    [SerializeField] private Animator UIAnimator;
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
    private bool isGameStarted = false;
    private bool isGameOver = false;
    private bool isPaused = false;
    private float lastGameOverTime = 1f;

    private void Awake()
    {
        CustomSpeedModifier = new List<float>();
        CustomSpeedModifier.Add(0f);
    }

    public void SetWorldSpeed(float speed)
    {
        worldSpeedMultiplier = speed;
    }

    public void StartGame()
    {
        if (isGameStarted) return;

        player.SetActive(true);
        isGameStarted = true;
        CustomSpeedModifier.Remove(0f);
    }

    public void EndGame()
    {
        if (isGameOver) return;

        lastGameOverTime = Time.timeScale;
        isGameOver = true;
        OnGameOver?.Invoke();
    }

    public void ReloadScene()
    {
        UIAnimator.SetBool("GameEnd", true);
    }
    private void Update()
    {
        if (!isGameOver) return;
        
        CustomSpeedModifier.Remove(lastGameOverTime);
        float newMod = Mathf.Lerp(lastGameOverTime, 0f, GameOverLerpSpeed);
        CustomSpeedModifier.Add(newMod);
        lastGameOverTime = newMod;
    }

    public void OnStartGame(InputAction.CallbackContext context)
    {
        if (context.started) StartGame();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(!isGameStarted || isGameOver) return;

        if (context.started)
            isPaused = !isPaused;

        if (isPaused) Pause();
        else PauseEnd();

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void PauseEnd()
    {
        Time.timeScale = 1f;
    }
}
