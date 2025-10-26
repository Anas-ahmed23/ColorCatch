using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;   // easy global access

    [Header("Gameplay Data")]
    public int score = 0;
    public Color targetColor;             // color the player should collect
    public float gameTime = 60f;          // total game time in seconds
    private bool gameOver = false;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public Image targetColorDisplay;
    public TextMeshProUGUI timerText;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f; // ensure game runs at normal speed
        SetRandomTargetColor();
        UpdateUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // hide Game Over at start
    }

    void Update()
    {
        if (!gameOver)
        {
            gameTime -= Time.deltaTime;

            // Update timer UI
            if (timerText != null)
                timerText.text = "Time: " + Mathf.CeilToInt(gameTime);

            if (gameTime <= 0)
            {
                gameTime = 0;
                EndGame();
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
    }

    public void SetRandomTargetColor()
    {
        Color[] colors = { Color.red, Color.green, Color.blue };
        targetColor = colors[Random.Range(0, colors.Length)];

        if (targetColorDisplay != null)
            targetColorDisplay.color = targetColor;
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f; // pause the game

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
