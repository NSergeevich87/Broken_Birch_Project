using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private SpawnManager spawnManager;

    private UIProgressBoss progressBoss;

    public float enemyMaxHealth = 10;
    public float enemyCurrentHealth;

    public UIHealthBar healthBar;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetMaxHealth(enemyMaxHealth);
        healthBar.gameObject.SetActive(true);
    }
    void Update()
    {
        if (enemyCurrentHealth == 0 && spawnManager.isAlive)
        {
            spawnManager.isAlive = false;
            Destroy(gameObject);
            deadReterner();
        }
        else if (enemyCurrentHealth == 0 && spawnManager.isBossAlive)
        {
            spawnManager.isBossAlive = false;
            Destroy(gameObject);
            deadReterner();
        }
    }

    public int deadReterner()
    {
        if (progressBoss.callBoss)
        {
            progressBoss.callBoss = false;
            return progressBoss.progressBossCount = 0;
        }
        else return progressBoss.progressBossCount += 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            TakeDamage(2f);
        }
    }

    void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        healthBar.SetHealth(enemyCurrentHealth);
    }
}
