using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI healthText;

    private void Start()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (game.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", game.score);
            highscoreText.text = "High Score: " + game.score;
        }

        //Change Score Text
        scoreText.text = "Score: " + game.score.ToString();

        healthText.text = "h: " + game.health.ToString();
    }

}
