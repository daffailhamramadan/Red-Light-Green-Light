using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI healthText;

    [SerializeField] GameController gameController;

    [SerializeField] GameObject pauseText;

    [SerializeField] GameObject gameoverText;

    [SerializeField] GameObject startButton;

    [SerializeField] GameObject resumeButton;

    [SerializeField] GameObject restartButton;

    [SerializeField] GameObject quitButton;

    private void Start()
    {
        if(gameController.gameState == GameController.GameState.Start)
        {
            highscoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }       
    }

    private void Update()
    {
        if (gameController.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", gameController.score);
            highscoreText.text = "High Score: " + gameController.score;
        }

        if(gameController.gameState == GameController.GameState.Play)
        {
            startButton.SetActive(false);
            pauseText.SetActive(false);
            resumeButton.SetActive(false);
            restartButton.SetActive(false);
            highscoreText.text = "";
        }

        if (gameController.gameState == GameController.GameState.Pause)
        {
            pauseText.SetActive(true);
            resumeButton.SetActive(true);
            restartButton.SetActive(true);
        }

        if (gameController.gameState == GameController.GameState.GameOver)
        {
            gameoverText.SetActive(true);
            restartButton.SetActive(true);
            quitButton.SetActive(true);

        }

        scoreText.text = "Score: " + gameController.score.ToString();

        healthText.text = "h: " + gameController.health.ToString();
    }

    public void GameOver()
    {
        gameController.gameState = GameController.GameState.GameOver;
    }

    public void Resume()
    {
        gameController.gameState = GameController.GameState.Play;
    }
    public void StartGame()
    {
        gameController.gameState = GameController.GameState.Play;
    }
    public void Restart()
    {
        gameController.gameState = GameController.GameState.Restart;
    }

    public void Quit()
    {
        gameController.gameState = GameController.GameState.Quit;
    }


}
