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
    private float bossMoy;

    private float distance; //расстояние между игроком и врагом
    void Start()
    {
        enemyBossMaxHealth = GameManager.Instance.enemyBossMaxHealth;
        bossATK = GameManager.Instance.bossATK;
        bossASPD = GameManager.Instance.bossASPD;
        bossSPD = GameManager.Instance.bossSPD;
        bossMoy = GameManager.Instance.bossMoy;

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
        Debug.Log(enemyBossMaxHealth + " " + bossATK + " " + bossMoy);

        distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1

        if (enemyCurrentHealth <= 0)
        {
            GameManager.Instance.PlayClip();

            Destroy(gameObject);
            GameManager.Instance.gold += bossMoy;
            GameManager.Instance.level += 1;
            GameManager.Instance.stage = 0;
            GameManager.Instance.isShouldUpStats = true;
            GameManager.Instance.isBoss = false;
        }
        if (distance > 1.5)
        {
            var pos = transform.localPosition;
            pos.x -= bossSPD * Time.deltaTime; 
            transform.localPosition = pos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
