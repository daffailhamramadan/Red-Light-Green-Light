using UnityEngine;

public class CircleMove : MonoBehaviour
{
    private float speed = 4f;

    void Update()
    {
        //Automatically moving to the up
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
