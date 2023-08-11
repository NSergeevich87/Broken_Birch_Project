using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    private SpawnManager spawnManager;
    private UIProgressBoss progressBoss;
    public UIHealthBar healthBar;

    private float enemyMaxHealth;
    public float enemyCurrentHealth;

    private float enemyASPD;
    private float enemyATK;
    private float enemySPD;
    private int enemyMoy;

    private float distance; //расстояние между игроком и врагом
    void Start()
    {
        BasicEnemy enemy = new BasicEnemy("cultista simple", 25, 100, 0.5f, 0.9f, 40);
        enemyATK = enemy.enemyATK;
        enemyASPD = enemy.enemyASPD;
        enemyMaxHealth = enemy.enemyHP;
        enemySPD = enemy.enemySPD;
        enemyMoy = enemy.enemyMOY;

        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("PlayerTakeDamage", 0, enemyASPD);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetMaxHealth(enemyMaxHealth);
        healthBar.gameObject.SetActive(true);
    }
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
        
        if (enemyCurrentHealth <= 0 && spawnManager.isAlive)
        {
            GameManager.Instance.gold += enemyMoy;

            spawnManager.isAlive = false;
            Destroy(gameObject);
            deadReterner();
        }
        if (distance > 3)
        {
            var pos = transform.localPosition;
            pos.x -= enemySPD * Time.deltaTime; //Mathf.MoveTowards(pos.x, -3, Time.deltaTime);
            transform.localPosition = pos;
        }
    }

    public int deadReterner()
    {
        return progressBoss.progressBossCount += 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        enemyCurrentHealth -= player.atk;
        healthBar.SetHealth(enemyCurrentHealth);
    }

    private void PlayerTakeDamage()
    {
        if (distance > 2.9 && distance < 3.1)
        {
            if (player.currentHealth > 0)
            {
                player.currentHealth -= enemyATK;
            }
            else
            {
                player.currentHealth = 0;
            }

        }
    }
}
