using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Attach this to an empty GameObject called "GameManager".
public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text scoreText;
    public GameObject gameOverPanel;

    private int score = 0;
    private bool isGameOver = false;

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;

        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}