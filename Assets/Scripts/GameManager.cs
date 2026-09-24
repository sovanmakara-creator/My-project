
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    [Header("Level Settings")]
    public int targetScore = 20;

    private int score = 0;
    private bool isGameOver = false;
    private bool isLevelComplete = false;

    public bool IsGameFinished
    {
        get { return isGameOver || isLevelComplete; }
    }

    void Start()
    {
        Time.timeScale = 1f;

        score = 0;
        isGameOver = false;
        isLevelComplete = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        if (IsGameFinished) return;

        score += amount;

        UpdateScoreUI();

        if (score >= targetScore)
        {
            LevelComplete();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score + " / " + targetScore;
        }
    }

    public void LevelComplete()
    {
        if (IsGameFinished) return;

        isLevelComplete = true;

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (IsGameFinished) return;

        isGameOver = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pausebtn()
    {
        if (IsGameFinished) return;

        Time.timeScale = 0f;
    }

    public void Replay()
    {
        if (IsGameFinished) return;

        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        // Replace this with your exact Main Menu scene name.
        SceneManager.LoadScene("Main Menu");
    }
}