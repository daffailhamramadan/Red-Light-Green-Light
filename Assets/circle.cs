using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    int[] numbers = new int[] { 3, 0, -3 };

    int randomIndex;

    Vector3 s_position;

    public float speed;

    void Start()
    {
        randomIndex = Random.Range(0, 3);

        //Start with random position on the list at "numbers"
        s_position = new Vector3(13.5f, numbers[randomIndex], 0);

        transform.position = s_position;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = Color.red;

    }
    void Update()
    {
        //Automatically moving to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //Destroy the object and Respawn the Circle to the start position 
        if (transform.position.x <= -15)
        {
            Instantiate(this.gameObject, s_position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    //When Mouse click the circle Change the color
    void OnMouseDown()
    {
        m_SpriteRenderer.color = Color.green;

    }
}
