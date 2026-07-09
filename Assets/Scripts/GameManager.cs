using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText;
    public GameObject winText;
    public GameObject gameOverText;

    public int winScore = 5;
    private int score = 0;

    void Awake()
    {
        Instance = this;

        score = 0;
        scoreText.text = "Score: 0";

        if (winText != null)
            winText.SetActive(false);

        if (gameOverText != null)
            gameOverText.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= winScore)
        {
            if (winText != null)
                winText.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {
        if (gameOverText != null)
            gameOverText.SetActive(true);

        Time.timeScale = 0f;
    }
}