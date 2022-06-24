using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HighscorePlugin;

public class UIController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] private Highscores highscores;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] TMP_Text gameScoreText;
    [SerializeField] TMP_Text endScoreText;
    [SerializeField] List<TMP_Text> highscoreTexts = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> highscoreValues = new List<TMP_Text>();
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] List<GameObject> lifeImages = new List<GameObject>();

    bool scoreSubmitted = false;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        
        gameController.OnGameOver += GameOver;
        gameController.Samurai.OnUpdateLife += UpdateLife;
        
        UpdateLife(gameController.Samurai.Life);
    }

    public void GameOver()
    {
        endScoreText.text = ((int)(gameController.Samurai.Score)).ToString();
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);

        highscores.OnHighscoresReceived += UpdateHighscores;
        highscores.GetHighscores(highscoreTexts.Count);
    }

    public void UpdateHighscores(List<SingleNameScore> _highscores)
    {
        for (int i = 0; i < highscoreTexts.Count; i++)
        {
            highscoreTexts[i].text = _highscores[i].name;
            highscoreValues[i].text = _highscores[i].score.ToString();
        }
    }

    public void SubmitScore()
    {
        if (scoreSubmitted) return;

        scoreSubmitted = true;
        highscores.CreateHighscore(nameInput.text, int.Parse(endScoreText.text));
        highscores.GetHighscores(highscoreTexts.Count);
    }

    public void UpdateLife(int _life)
    {
        for (int i = 0; i < lifeImages.Count; i++)
            lifeImages[i].SetActive(i < _life);
    }

    void Update()
    {
        gameScoreText.text = ((int)(gameController.Samurai.Score)).ToString();
    }
}
