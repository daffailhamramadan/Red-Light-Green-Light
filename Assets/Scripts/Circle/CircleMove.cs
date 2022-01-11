using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        //Automatically moving to the up
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
