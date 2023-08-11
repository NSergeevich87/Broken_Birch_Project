using System;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private Player player;
    private SpawnManager spawnManager;
    public ParticleSystem particleBossAttack;
    private UIProgressBoss progressBoss;
    public UIHealthBar healthBar;

    private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;

    private float bossASPD;
    private float bossATK;
    private float bossSPD;
    private int bossMoy;

    private float distance; //расстояние между игроком и врагом
    void Start()
    {
        BasicBoss boss = new BasicBoss("cultista mayor", 40, 2000, 0.5f, 1, 250);
        bossASPD = boss.enemyASPD;
        bossATK = boss.enemyATK;
        bossSPD = boss.enemySPD;
        enemyMaxHealth = boss.enemyHP;
        bossMoy = boss.enemyMOY;

        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("PlayerTakeDamage", 0, bossASPD);
        particleBossAttack.Pause();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        progressBoss = GameObject.Find("ProgressBar").GetComponent<UIProgressBoss>();
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetMaxHealth(enemyMaxHealth);
        healthBar.gameObject.SetActive(true);
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
        
        if (enemyCurrentHealth <= 0)
        {
            GameManager.Instance.gold += bossMoy;
            GameManager.Instance.level += 1;
            GameManager.Instance.stage = 1;

            spawnManager.isBossAlive = false;
            Destroy(gameObject);
            deadReterner();
        }
        if (distance > 3)
        {
            var pos = transform.localPosition;
            pos.x -= bossSPD * Time.deltaTime; //Mathf.MoveTowards(pos.x, -3, Time.deltaTime);
            transform.localPosition = pos;
        }
    }
    public void deadReterner()
    {
        GameManager.Instance.stage = 1;
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
            particleBossAttack.Play();
            if (player.currentHealth > 0)
            {
                player.currentHealth -= bossATK;
            }
            else
            {
                player.currentHealth = 0;
            }

        }
    }
}
