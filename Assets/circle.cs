using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    int[] numbers = new int[] { 3, 0, -3 };

    int randomIndex;

    public float speed;

    float x_position;

    Camera cam;

    float cam_height;

    float cam_width;

    public bool Boolean;

    Renderer rend;

    void Start()
    {

        //Sometimes the circle appears sometimes not
        rend = GetComponent<Renderer>();

        Boolean = Random.value > 0.3f;

        rend.enabled = Boolean;

        //Start with color "red"
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = Color.red;

        //Start circle position x right and close outside camera
        cam = Camera.main;

        cam_height = 2f * cam.orthographicSize;

        cam_width = cam_height * cam.aspect;

        x_position = cam_width / 2 + 3;

        transform.position = new Vector3(x_position, transform.position.y, 0);



    }


    void Update()
    {
        //When left outside camera respawn the circle
        if (transform.position.x <= cam_width / -2 - 3)
        {
            Boolean = Random.value > 0.3f;

            rend.enabled = Boolean;

            transform.position = new Vector3(x_position, transform.position.y, 0);

            m_SpriteRenderer.color = Color.red;
        }

        //Automatically moving to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }

    //When Mouse click the circle Change the color
    void OnMouseDown()
    {
        m_SpriteRenderer.color = Color.green;

    }
 
}
