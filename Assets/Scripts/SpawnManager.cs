using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObstacle;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnObstacleMetod", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacleMetod()
    {
        int randomObstacle = Random.Range(0, spawnObstacle.Length);
        Instantiate(spawnObstacle[randomObstacle], transform.position, transform.rotation);
    }
}
