using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private ProgressBoss progressBoss;

    public GameObject[] enemySpawn;
    private int enemyCount;

    public bool isAlive = false; //есть ли активный враг
    public bool isBossAlive = false;
    void Start()
    {
        progressBoss = GameObject.Find("ProgressBar").GetComponent<ProgressBoss>();
        InvokeRepeating("SpawnEnemy", 0, 4);
    }


    void SpawnEnemy()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 && progressBoss.callBoss == false)
        {
            StartSpawnEnemy(0);
        }
        else if (enemyCount == 0 && progressBoss.callBoss == true)
        {
            StartSpawnEnemy(1);
        }
    }


    void StartSpawnEnemy(int enemy)
    {
        if (enemy == 0)
        {
            Instantiate(enemySpawn[enemy], transform.position, enemySpawn[enemy].transform.rotation);
            isAlive = true;
        }
        if (enemy == 1)
        {
            Instantiate(enemySpawn[enemy], transform.position, enemySpawn[enemy].transform.rotation);
            isBossAlive = true;
        }
    }
}
