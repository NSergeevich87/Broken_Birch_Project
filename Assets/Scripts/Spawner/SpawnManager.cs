using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private UIProgressBoss progressBoss;

    public GameObject[] enemySpawn;

    public bool isAlive = false; //есть ли активный враг
    public bool isBossAlive = false;
    void Start()
    {
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        InvokeRepeating("SpawnEnemy", 0, 4);
    }


    void SpawnEnemy()
    {
        if (progressBoss.callBoss == false && isBossAlive == false && isAlive == false)
        {
            StartSpawnEnemy(0);
        }
        else if (progressBoss.callBoss == true)
        {
            progressBoss.callBoss = false;
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
