using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    [SerializeField] Transform circleParent;

    [SerializeField] GameObject circle;

    GameObject[] circleClone = new GameObject[3];

    float timer = 0.4f;

    float time;

    Vector3[] startPosition = new Vector3[3];

    bool[] Boolean = new bool[3];

    void Start()
    { 
        startPosition[0] = transform.position;

        startPosition[1] = new Vector3(-1.5f, transform.position.y, 0f);

        startPosition[2] = new Vector3(1.5f, transform.position.y, 0f);

    
    }

    void Update()
    {

        //Respawn and destroy the circle
        if(time > timer)
        {
            circleClone[0] = Instantiate(circle, startPosition[0], Quaternion.identity, circleParent);

            circleClone[1] = Instantiate(circle, startPosition[1], Quaternion.identity, circleParent);

            circleClone[2] = Instantiate(circle, startPosition[2], Quaternion.identity, circleParent);

            Boolean[0] = Random.value > 0.3f;

            Boolean[1] = Random.value > 0.3f;

            Boolean[2] = Random.value > 0.3f;

            circleClone[0].SetActive(Boolean[0]);

            circleClone[1].SetActive(Boolean[1]);

            circleClone[2].SetActive(Boolean[2]);

            time = 0f;

            Destroy(circleClone[0], 10f);

            Destroy(circleClone[1], 10f);

            Destroy(circleClone[2], 10f);

        }

        //Timer
        time += Time.deltaTime;
     
    }
    
}
