using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        Start,

        GameOver,
    }


    [SerializeField] GameRule game;

    [SerializeField] GameObject pauseText;

    [SerializeField] GameObject gameoverText;

    [SerializeField] GameObject startButton;

    [SerializeField] GameObject highScore;

    [SerializeField] GameObject resumeButton;

    [SerializeField] GameObject restart;

    private AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();

        game.isStart = true;

        game.isGameover = false;

        game.score = 0;

        game.health = 3;        

        Time.timeScale = 0;   
    }

    void Update()
    {


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
