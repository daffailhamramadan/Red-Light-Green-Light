using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class CircleTouch : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;

    private AudioSource audioSource;

    public GameRule game;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
      
        //Start with color "red"
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = Color.red;

    }

    void Update()
    {

        //Change Color to green when touch (multi touch) the circle and add score +1 
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (hit.collider != null && hit.transform == transform && touch.phase == TouchPhase.Began && m_SpriteRenderer.color == Color.red && game.isGameover != true && game.isPaused != true)
            { 
                m_SpriteRenderer.color = Color.green;

                game.score += 1;

                audioSource.Play();
            }
        }
        
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
