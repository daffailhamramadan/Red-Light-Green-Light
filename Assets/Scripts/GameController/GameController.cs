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

        Restart,
        
        Quit,
    }

    public GameState gameState;

    public int score;

    public int health;

    void Start()
    {
        gameState = GameState.Start;       
        
        if(gameState == GameState.Start)
        {
            Time.timeScale = 0f;

            score = 0;

            health = 3;
        }
    }

    void Update()
    {

        if(gameState == GameState.Play)
        {
            Time.timeScale = 1f;
        }

        if (gameState == GameState.GameOver)
        {
            health = 0;
            Time.timeScale = 0f;
        }

        if (gameState == GameState.Restart)
        {
            SceneManager.LoadScene(0);
        }

        if(gameState == GameState.Quit)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameState != GameState.Start)
        {
            gameState = GameState.Pause;

            if (gameState == GameState.Pause)
            {
                Time.timeScale = 0f;
            }
        }

        if(health <= 0)
        {
            gameState = GameState.GameOver;
        }
        
    }

}
