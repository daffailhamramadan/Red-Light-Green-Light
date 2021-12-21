using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public static bool isGameover;

    public static bool isPaused;

    bool is_start = true;

    public Score score;

    public static int health;

    public GameObject pauseText;

    public GameObject gameoverText;

    public GameObject startButton;

    public GameObject highScore;

    public GameObject resumeButton;

    public GameObject restart;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI healthText;

    AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
        
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        score.value = 0;

        health = 3;

        isGameover = false;

        Time.timeScale = 0;   
    }

    void Update()
    {
        if (score.value > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score.value);
            highscoreText.text = "High Score: " + score.value;
        }

        //Change Score Text
        scoreText.text = "Score: " + score.value.ToString();

        healthText.text = "h: " + GameController.health.ToString();

        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused != true && is_start != true)
            {
                Pause();
                pauseText.SetActive(true);
                resumeButton.SetActive(true);
            }

            //Quit Game
            else if(isPaused == true && is_start != true)
            {
                Application.Quit();
            }
            else if(is_start == true)
            {
                Application.Quit();
            }
        }

        if(health <= 0)
        {
            health = 0;
            isGameover = true;
        }

        //Game_Over
        if(GameController.isGameover == true)
        {
            GameOver();
            isPaused = true;
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
        isPaused = true;
        highScore.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseText.SetActive(false);
        isPaused = false;
        resumeButton.SetActive(false);
        highScore.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        music.Play();
        isPaused = false;
        is_start = false;
        highScore.SetActive(false);
        startButton.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
