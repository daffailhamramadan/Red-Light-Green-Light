using UnityEngine;

[CreateAssetMenu(menuName = "GameRule")]
public class GameRule : ScriptableObject
{
    public int score;

    public int health;

    public bool isGameover;

    public bool isPaused;

    public bool isStart;
}
