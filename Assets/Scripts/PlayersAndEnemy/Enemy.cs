using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    private SpawnManager spawnManager;
    private UIProgressBoss progressBoss;
    public UIHealthBar healthBar;

    private float enemyMaxHealth;
    [SerializeField] private float enemyCurrentHealth;

    private float enemyASPD;
    private float enemyATK;
    void Start()
    {
        BasicEnemy enemy = new BasicEnemy("cultista simple", 25, 1000, 0.5f, 40);
        enemyATK = enemy.enemyATK;
        enemyASPD = enemy.enemyASPD;
        enemyMaxHealth = enemy.enemyHP;

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
        if (enemyCurrentHealth <= 0 && spawnManager.isAlive)
        {
            spawnManager.isAlive = false;
            Destroy(gameObject);
            deadReterner();
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
        if (transform.position.x == 2)
        {
            player.currentHealth -= enemyATK;
        }
    }
}
