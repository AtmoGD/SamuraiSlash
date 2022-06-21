using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] TMP_Text gameScoreText;
    [SerializeField] TMP_Text endScoreText;
    [SerializeField] GameController gameController;
    private void Start() {
        gameController.OnGameOver += GameOver;
    }

    public void GameOver() {
        endScoreText.text = ((int)(gameController.Samurai.Score)).ToString();
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    void Update()
    {
        gameScoreText.text = ((int)(gameController.Samurai.Score)).ToString();
    }
}
