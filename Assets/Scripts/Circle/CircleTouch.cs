using UnityEngine;

public class CircleTouch : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;

    private AudioSource audioSource;

    private GameController gameController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        m_SpriteRenderer.color = Color.red;

    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (hit.collider != null && hit.transform == transform && touch.phase == TouchPhase.Began && m_SpriteRenderer.color == Color.red && gameController.gameState == GameController.GameState.Play) 
            { 
                m_SpriteRenderer.color = Color.green;

                gameController.score += 1;

                audioSource.Play();
            }
        }
        
    }
     
}
