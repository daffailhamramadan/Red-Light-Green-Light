using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public GameObject Pause_text;

    public GameObject GameOver_text;

    public static bool game_over;

    public static bool is_paused;

    bool is_start = true;

    public static int score = 0;

    public GameObject Start_button;

    public GameObject High_Score;

    public GameObject resume_button;

    public GameObject restart;

    public TextMeshProUGUI score_Text;

    public TextMeshProUGUI highscore_Text;

    AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
        
        highscore_Text.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        Time.timeScale = 0;   
    }

    void Update()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore_Text.text = "High Score: " + score;
        }

        //Change Score Text
        score_Text.text = "Score: " + GameController.score.ToString();

        //Pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (is_paused != true && is_start != true)
            {
                Pause();
                Pause_text.SetActive(true);
                resume_button.SetActive(true);
            }

            //Resume Game
            else if(is_paused == true && is_start != true)
            {
                Application.Quit();
            }
            else if(is_start == true)
            {
                Application.Quit();
            }
        }

        //Game_Over
        if(GameController.game_over == true)
        {
            GameOver();
            is_paused = true;
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
        High_Score.SetActive(true);
        GameOver_text.SetActive(true);
    }

    void Pause()
    {
        is_paused = true;
        High_Score.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Pause_text.SetActive(false);
        is_paused = false;
        resume_button.SetActive(false);
        High_Score.SetActive(false);
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        music.Play();
        is_paused = false;
        is_start = false;
        High_Score.SetActive(false);
        Start_button.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        restart.SetActive(false);
        game_over = false;
        Time.timeScale = 1f;
        score = 0;
        SceneManager.LoadScene(0);
    }
}
