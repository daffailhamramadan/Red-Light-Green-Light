using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class circle : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    public GameObject m_light;

    public Light2D g_light;

    public float speed;

    Camera cam;

    float cam_height;

    bool Boolean;

    Renderer rend;

    float y_position;

    void Start()
    {

        //Sometimes the circle appears sometimes not
        rend = GetComponent<Renderer>();

        Boolean = Random.value > 0.3f;

        rend.enabled = Boolean;

        //Start with color "red"
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_SpriteRenderer.color = Color.red;

        //Start circle position y down and close outside camera
        cam = Camera.main;

        cam_height = 2f * cam.orthographicSize;

        y_position = cam_height / -2 - 3;

        transform.position = new Vector3(transform.position.x,y_position, 0);

        //Start the Respawn method
        StartCoroutine(Spawn());

    }

    //Respawn the Circle every 0.5 seconds
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(this.gameObject);
    }

    void Update()
    {
        if(rend.enabled == false)
        {
            m_light.SetActive(false);
        }
        else if (rend.enabled == true)
        {
            m_light.SetActive(true);
        }

        //Change Color to greeen when touch the circle
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (hit.collider != null && hit.transform == transform && touch.phase == TouchPhase.Began && rend.enabled == true)
            {
                g_light = GetComponentInChildren<Light2D>();

                m_SpriteRenderer.color = Color.green;

                g_light.color = Color.green;
                
            }

        }

        //Automatically moving to the left
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //When left outside camera destroy the circle
        if (transform.position.y >= cam_height / 2 + 3)
        {
            Destroy(this.gameObject);

        }

    }
 
}
