using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool isMasStage = true;
    public GameObject[] enemySpawn;

    private float playerDistance;
    void Awake()
    {
        if (GameManager.Instance.stage == 9)
        {
            StartSpawnBoss();
        }
        else StartSpawnEnemy();
    }
    private void Update()
    {
        if (GameManager.Instance.stage == 9)
        {
            GameManager.Instance.isBoss = true;
        }
    }
    void LateUpdate()
    {
        if (GameManager.Instance.bSpawn)
        {
            if (!GameObject.FindGameObjectWithTag("Enemy") && !(GameManager.Instance.stage == 9))
            {
                if (isMasStage) GameManager.Instance.stage += 1;
                StartSpawnEnemy();
            }
            else if (!GameObject.FindGameObjectWithTag("Enemy") && (GameManager.Instance.stage == 9))
            {
                StartSpawnBoss();
            }
        }

        playerDistance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

        if (playerDistance < 15)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
    }

    void StartSpawnEnemy()
    {
        float[] linesSpawn = new[] { 2.2f, 2.7f, 3.2f, 3.7f, 4.2f, 4.7f, 5.2f};

        if (GameManager.Instance.isShouldUpStats)
        {
            //повышаем характеристики
            GameManager.Instance.EnemyStatsUp();
            GameManager.Instance.isShouldUpStats = false;
        }

        /*for (int i = 0; i < GameManager.Instance.stage; i++)
        {
            float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
            Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
            Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
        }*/

        switch (GameManager.Instance.stage) 
        {
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break; 
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 4:
                for (int i = 0; i < 3; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 5:
                for (int i = 0; i < 3; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 6:
                for (int i = 0; i < 3; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 7:
                for (int i = 0; i < 4; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 8:
                for (int i = 0; i < 4; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
            case 9:
                for (int i = 0; i < 5; i++)
                {
                    float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
                    Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
                    Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
                }
                break;
        }
    }

    void StartSpawnBoss()
    {
        Instantiate(enemySpawn[1], transform.position, enemySpawn[1].transform.rotation);
    }

    public void SetIsMasStage(bool value)
    {
        isMasStage = value;
    }
}