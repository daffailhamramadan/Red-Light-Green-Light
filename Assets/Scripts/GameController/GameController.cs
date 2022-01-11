using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameRule game;

    public GameObject pauseText;

    public GameObject gameoverText;

    public GameObject startButton;

    public GameObject highScore;

    public GameObject resumeButton;

    public GameObject restart;

    AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
        
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        game.isStart = true;

        game.isGameover = false;

        game.score = 0;

        game.health = 3;        

        Time.timeScale = 0;   
    }

    void Update()
    {
        if (game.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", game.score);
            highscoreText.text = "High Score: " + game.score;
        }

        //Change Score Text
        scoreText.text = "Score: " + game.score.ToString();

        healthText.text = "h: " + game.health.ToString();

        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game.isPaused != true && game.isStart != true)
            {
                Pause();
                pauseText.SetActive(true);
                resumeButton.SetActive(true);
            }

            //Quit Game
            else if(game.isPaused == true && game.isStart != true)
            {
                Application.Quit();
            }
            else if(game.isStart == true)
            {
                Application.Quit();
            }
        }

        if(game.health <= 0)
        {
            game.health = 0;
            game.isGameover = true;
        }

        //Game_Over
        if(game.isGameover == true)
        {
            GameOver();
            game.isPaused = true;
            restart.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        
    }

    void GameOver()
    {
        music.Stop();
        Time.timeScale = 0f;
        highScore.SetActive(true);
        gameoverText.SetActive(true);
    }

    void Pause()
    {
        game.isPaused = true;
        highScore.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        pauseText.SetActive(false);
        game.isPaused = false;
        resumeButton.SetActive(false);
        highScore.SetActive(false);
        Time.timeScale = 1f;
    }
    void StartGame()
    {
        music.Play();
        game.isPaused = false;
        game.isStart = false;
        highScore.SetActive(false);
        startButton.SetActive(false);
        Time.timeScale = 1f;
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
