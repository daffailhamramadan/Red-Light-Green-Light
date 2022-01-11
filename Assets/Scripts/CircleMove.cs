using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    private float speed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        //Automatically moving to the up
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
