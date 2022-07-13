using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HighscorePlugin;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] private Highscores highscores;
    [SerializeField] private GameObject startPanel;
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
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(false);
        
        gameController.OnGameOver += GameOver;
        gameController.Samurai.OnUpdateLife += UpdateLife;
        highscores.OnHighscoresReceived += UpdateHighscores;
        
        UpdateLife(gameController.Samurai.Life);
        LoadHighscores();
    }

    public void StartGame() {
        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameController.StartGame();
    }

    public void GameOver()
    {
        endScoreText.text = ((int)(gameController.Samurai.Score)).ToString();
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void LoadHighscores() {
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
