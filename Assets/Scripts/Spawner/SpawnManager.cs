using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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
        if (!GameObject.FindGameObjectWithTag("Enemy") && !(GameManager.Instance.stage == 9))
        {
            GameManager.Instance.stage += 1;
            StartSpawnEnemy();
        }
        else if (!GameObject.FindGameObjectWithTag("Enemy") && (GameManager.Instance.stage == 9))
        {
            StartSpawnBoss();
        }

        playerDistance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

        if (playerDistance < 10)
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

        for (int i = 0; i < GameManager.Instance.stage; i++)
        {
            float rndLine = linesSpawn[Random.Range(0, linesSpawn.Length)];
            Vector3 spawnPlace = new Vector3(transform.position.x + Random.Range(0, 4), rndLine, transform.position.z);
            Instantiate(enemySpawn[0], spawnPlace, enemySpawn[0].transform.rotation);
        }
    }

    void StartSpawnBoss()
    {
        Instantiate(enemySpawn[1], transform.position, enemySpawn[1].transform.rotation);
    }
}
