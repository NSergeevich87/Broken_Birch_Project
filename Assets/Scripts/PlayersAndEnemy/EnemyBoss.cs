using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private Player player;
    private SpawnManager spawnManager;
    public ParticleSystem particleBossAttack;
    public UIHealthBar healthBar;

    private float enemyBossMaxHealth;
    [SerializeField] private float enemyCurrentHealth;

    private float bossASPD;
    private float bossATK;
    private float bossSPD;
    private int bossMoy;

    private float distance; //расстояние между игроком и врагом
    void Start()
    {
        /*BasicBoss boss = new BasicBoss("cultista mayor", 40, 2000, 0.5f, 1, 250);
        bossASPD = boss.enemyASPD;
        bossATK = boss.enemyATK;
        bossSPD = boss.enemySPD;
        enemyMaxHealth = boss.enemyHP;
        bossMoy = boss.enemyMOY;*/

        enemyBossMaxHealth = GameManager.Instance.enemyBossMaxHealth;
        bossATK = GameManager.Instance.enemyATK;
        bossASPD = GameManager.Instance.enemyASPD;
        bossSPD = GameManager.Instance.enemySPD;
        bossMoy = GameManager.Instance.enemyMoy;

        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("PlayerTakeDamage", 0, bossASPD);
        particleBossAttack.Pause();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyCurrentHealth = enemyBossMaxHealth;
        healthBar.SetMaxHealth(enemyBossMaxHealth);
        healthBar.gameObject.SetActive(true);
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1

        if (enemyCurrentHealth <= 0)
        {
            GameManager.Instance.PlayClip();

            Destroy(gameObject);
            GameManager.Instance.gold += bossMoy;
            GameManager.Instance.level += 1;
            GameManager.Instance.stage = 0;
            GameManager.Instance.isShouldUpStats = true;

            //spawnManager.isBossAlive = false;
            GameManager.Instance.isBoss = false;

            //deadReterner();
        }
        if (distance > 1.5)
        {
            var pos = transform.localPosition;
            pos.x -= bossSPD * Time.deltaTime; //Mathf.MoveTowards(pos.x, -3, Time.deltaTime);
            transform.localPosition = pos;
        }
    }
    /*public void deadReterner()
    {
        GameManager.Instance.stage = 1;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }*/

    void TakeDamage()
    {
        enemyCurrentHealth -= player.atk;
        healthBar.SetHealth(enemyCurrentHealth);
    }
    private void PlayerTakeDamage()
    {
        if (distance > 0 && distance < 1.6)
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
