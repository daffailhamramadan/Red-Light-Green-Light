using UnityEngine;

public class CircleOut : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;

    public GameRule game;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    //If circle cross the line "Game Over"
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Line") && m_SpriteRenderer.color == Color.red)
        {
            game.health -= 1;
        }


    }
}
