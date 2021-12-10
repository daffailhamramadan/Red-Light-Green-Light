using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.red;

    }

    //When Mouse click the circle Change the color
    void OnMouseDown()
    {
        m_SpriteRenderer.color = Color.blue;
    }
}
