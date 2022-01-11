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
}
