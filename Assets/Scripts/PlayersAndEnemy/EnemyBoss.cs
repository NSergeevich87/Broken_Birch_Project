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
    void Start()
    {
        BasicBoss boss = new BasicBoss("cultista mayor", 40, 2000, 0.5f, 250);
        bossASPD = boss.enemyASPD;
        bossATK = boss.enemyATK;
        enemyMaxHealth = boss.enemyHP;

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
        if (enemyCurrentHealth <= 0 && spawnManager.isBossAlive)
        {
            spawnManager.isBossAlive = false;
            Destroy(gameObject);
            deadReterner();
        }
    }
    public int deadReterner()
    {
        return progressBoss.progressBossCount = 0;
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
            particleBossAttack.Play();
            player.currentHealth -= bossATK;
        }
    }
}
