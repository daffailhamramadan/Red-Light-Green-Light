using UnityEngine;

public class CircleOut : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;

    private GameController gameController;

    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Line") && m_SpriteRenderer.color == Color.red)
        {
            gameController.health -= 1;
        }


    }
}
