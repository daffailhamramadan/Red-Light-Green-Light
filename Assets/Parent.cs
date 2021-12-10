using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{

    public float speed;

    //Start Position
    Vector3 s_position;

    // Start is called before the first frame update
    void Start()
    {
        s_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Automatically moving to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //Destroy the object and Respawn the Circle to the start position 
        if (transform.position.x <= -45)
        {
            Instantiate(this.gameObject, s_position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
