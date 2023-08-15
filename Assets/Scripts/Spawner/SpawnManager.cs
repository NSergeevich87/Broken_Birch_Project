using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private UIProgressBoss progressBoss;

    public GameObject[] enemySpawn;

    public bool isAlive = false; //есть ли активный враг
    public bool isBossAlive = false;

    private float playerDistance;
    void Start()
    {
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        InvokeRepeating("SpawnEnemy", 0, 2);
    }

    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

        if (playerDistance < 10)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
    }

    void SpawnEnemy()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            if (GameManager.Instance.stage != 9 && progressBoss.callBoss == false && isBossAlive == false && isAlive == false)
            {
                StartSpawnEnemy(0);
            }
            else if (progressBoss.callBoss == true)
            {
                progressBoss.callBoss = false;
                StartSpawnEnemy(1);
            }
        }
    }


    void StartSpawnEnemy(int enemy)
    {
        int spawnCount = Random.Range(1, 5);

        if (enemy == 0)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 3), Random.Range(2.75f, 4.75f), transform.position.z);
                Instantiate(enemySpawn[enemy], spawnPlace, enemySpawn[enemy].transform.rotation);
                isAlive = true;
            }

        }
        if (enemy == 1)
        {
            Instantiate(enemySpawn[enemy], transform.position, enemySpawn[enemy].transform.rotation);
            isBossAlive = true;
        }
    }
}
