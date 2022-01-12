using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        Start,

        Play,

        Pause,

        GameOver,
    }

    private GameState gameState;

    [SerializeField] GameRule game;

    [SerializeField] GameObject pauseText;

    [SerializeField] GameObject gameoverText;

    [SerializeField] GameObject startButton;

    [SerializeField] GameObject highScore;

    [SerializeField] GameObject resumeButton;

    [SerializeField] GameObject restart;

    private AudioSource music;

    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameState = GameState.Start;       

        game.isStart = true;

        game.isGameover = false;

        game.score = 0;

        game.health = 3;        

        Time.timeScale = 0;   
    }

    void Update()
    {
        Debug.Log(gameState);

        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == GameState.Pause)
            {
                Pause();
                pauseText.SetActive(true);
                resumeButton.SetActive(true);
            }

            else if(gameState == GameState.Start)
            {
                Application.Quit();
            }
        }

        if(game.health <= 0)
        {
            game.health = 0;
            gameState = GameState.GameOver;
        }


        //Game_Over
        if(gameState == GameState.GameOver)
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
