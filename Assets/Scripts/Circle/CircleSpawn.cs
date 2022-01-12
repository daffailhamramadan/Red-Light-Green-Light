using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    [SerializeField] Transform circleParent;

    [SerializeField] GameObject circle;

    private GameObject[] circleClone = new GameObject[3];

    private float timer = 0.4f;

    private float time;

    private Vector3[] startPosition = new Vector3[3];

    private bool[] Boolean = new bool[3];

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
            for(int i = 0; i < circleClone.Length; i++)
            {
                circleClone[i] = Instantiate(circle, startPosition[i], Quaternion.identity, circleParent);

                Boolean[i] = Random.value > 0.3f;

                circleClone[i].SetActive(Boolean[i]);

                Destroy(circleClone[i], 10f);

            }
           
            time = 0f;

        }

        //Timer
        time += Time.deltaTime;
     
    }
    
}
