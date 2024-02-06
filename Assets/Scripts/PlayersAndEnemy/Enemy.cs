using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    private SpawnManager spawnManager;

    private AudioSource AudioClips;
    public AudioClip AttackSound;

    public UIHealthBar healthBar;
    private float enemyMaxHealth;
    public float enemyCurrentHealth;

    private float enemyASPD;
    private float enemyATK;
    private float enemySPD;
    private float enemyMoy;

    private float spawnDistance; //���������� ����� ������� � ������
    private float distance; //���������� ����� ������� � ������
    private float linePos; //�� ����� ����� �������� ����
    private Vector3 target;

    void Start()
    {
        AudioClips = GetComponent<AudioSource>();

        enemyMaxHealth = GameManager.Instance.enemyMaxHealth;
        enemyATK = GameManager.Instance.enemyATK;
        enemyASPD = GameManager.Instance.enemyASPD;
        enemySPD = GameManager.Instance.enemySPD;
        enemyMoy = GameManager.Instance.enemyMoy;


        linePos = transform.position.y;


        //player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("PlayerTakeDamage", 0, enemyASPD);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnDistance = Vector3.Distance(spawnManager.transform.position, transform.position);
        enemyCurrentHealth = enemyMaxHealth;
        healthBar.SetMaxHealth(enemyMaxHealth);
        healthBar.gameObject.SetActive(true);
    }
    void LateUpdate()
    {
        //linePos = transform.position.y;
        spawnDistance = Vector3.Distance(spawnManager.transform.position, transform.position);

        switch (linePos) //2.2f, 2.7f, 3.2f, 3.7f, 4.2f, 4.7f, 5.2
        {
            case 5.2f:
                if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 4.7f:
                if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 4.2f:
                if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 3.7f:
                if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 3.2f:
                if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 2.7f:
                if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
            case 2.2f:
                if (GameObject.Find("Player2"))
                {
                    player = GameObject.Find("Player2").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player4"))
                {
                    player = GameObject.Find("Player4").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                else if (GameObject.Find("Player3"))
                {
                    player = GameObject.Find("Player3").GetComponent<Player>();
                    distance = Vector3.Distance(player.transform.position, transform.position); //distance <= 3.1
                    if (distance >= 1f && spawnDistance > 8)
                    {
                        target = player.transform.position - transform.position;
                        transform.position += target.normalized * Time.deltaTime * enemySPD;
                    }
                    else if (distance >= 1.5f)
                    {
                        target = transform.localPosition;
                        target.x -= enemySPD * Time.deltaTime;
                        transform.localPosition = target;
                    }
                }
                break;
        }

        if (enemyCurrentHealth <= 0 || spawnDistance > 20)
        {
            //GameManager.Instance.PlayClip();

            //GameManager.Instance.gold += enemyMoy;
            GameManager.Instance.PlaySoundEnemyDeath();
            GameManager.Instance.PlaySoundCoinsTake();
            Destroy(gameObject);
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
        if (player != null)
        {
            enemyCurrentHealth -= player.atk;
            healthBar.SetHealth(enemyCurrentHealth);
        }

    }

    private void PlayerTakeDamage()
    {
        if (distance > 0 && distance < 1.6)
        {
            if (player.currentHealth > 0)
            {
                AudioClips.PlayOneShot(AttackSound, 1.0f);
                player.currentHealth -= enemyATK;
            }
            else
            {
                player.currentHealth = 0;
            }
        }
    }
}
