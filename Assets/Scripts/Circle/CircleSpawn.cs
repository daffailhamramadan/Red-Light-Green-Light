using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    [SerializeField] Transform circleParent;

    [SerializeField] GameObject circle;

    private GameObject[] circleClone = new GameObject[3];

    private float timer = 0.4f;

    private float time;

    private Vector3[] startPosition = new Vector3[3];

    private float[] positionX = { 0f, -1.5f, 1.5f };

    private bool[] Boolean = new bool[3];

    void Start()
    { 
        for(int i = 0; i < startPosition.Length; i++)
        {
            startPosition[i] = new Vector3(positionX[i], transform.position.y, 0f);
        }
    
    }

    void Update()
    {
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

        time += Time.deltaTime;
     
    }
    
}
