using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private UIProgressBoss progressBoss;

    public GameObject[] enemySpawn;

    //public bool isAlive = false; //���� �� �������� ����
    //public bool isBossAlive = false;

    private float playerDistance;
    void Start()
    {
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        InvokeRepeating("SpawnEnemy", 0, 3);
    }

    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

        if (playerDistance < 10)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        if (GameManager.Instance.stage == 9)
        {
            GameManager.Instance.isBoss = true;
        }
    }

    void SpawnEnemy()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {

            if (GameManager.Instance.stage < 9 && GameManager.Instance.isBoss == false)
            {
                GameManager.Instance.stage += 1;
                StartSpawnEnemy(0);
            }
            else if (GameManager.Instance.isBoss == true)
            {
                StartSpawnEnemy(1);
            }
        }
    }


    void StartSpawnEnemy(int enemy)
    {
        float[] linesSpawn = new[] { 2.2f, 2.7f, 3.2f, 3.7f, 4.2f, 4.7f, 5.2f};

        int spawnCount = Random.Range(1, 5);

        if (enemy == 0)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                Instantiate(enemySpawn[enemy], spawnPlace, enemySpawn[enemy].transform.rotation);
                //isAlive = true;
            }

        }
        if (enemy == 1)
        {
            Instantiate(enemySpawn[enemy], transform.position, enemySpawn[enemy].transform.rotation);
            //isBossAlive = true;
        }
    }
}
