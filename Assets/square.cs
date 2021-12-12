using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.touchCount > 0)
       {
            Touch touch = Input.GetTouch(0);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if(hit.collider != null)
            {
                m_SpriteRenderer.color = Color.green;
            }
          

       }
    }
  

}
