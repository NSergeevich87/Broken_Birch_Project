using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private SpawnManager spawnManager;

    public Animator animator;

    private AudioSource audioClips;
    public AudioClip magicSpell;

    //public UIHealthBar healthBar;
    public PlayeOneHealthBar healthBar;
    private float maxHealth;
    public float currentHealth;

    public GameObject bomb;
    
    private float aspd;
    public float atk { get; private set; }

    private float distance = 10;
    private float curDistance;
    [SerializeField] private float speedMove;
    private float timeElapsed = 0f;

    private bool isPlayerDead;

    //enemy coounter
    private int enemyCounter;
    private int tar;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        audioClips = GetComponent<AudioSource>();

        maxHealth = GameManager.Instance.playerHp;
        aspd = GameManager.Instance.playerAspd;
        atk = GameManager.Instance.playerAtk;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void LateUpdate()
    {
        //–ывок вперед если босс убит
        /*if (GameManager.Instance.isBossDead == true)
        {
            GameManager.Instance.isBossDead = false;
            speedMove = 20;
            PlayerMove();
            StartCoroutine(Wait(1));
        }*/

        //Debug.Log(atk + " " + maxHealth + " " + aspd);
        //јвто–еген ’ѕ
        if (currentHealth < maxHealth)
        {
            currentHealth += (maxHealth * 0.02f) * Time.deltaTime;
        }

        healthBar.SetHealth(currentHealth);
        maxHealth = GameManager.Instance.playerHp;
        aspd = GameManager.Instance.playerAspd;
        atk = GameManager.Instance.playerAtk;

        if (currentHealth <= 1)
        {
            GameManager.Instance.stage = 0;
            GameManager.Instance.isBoss = false;
            TransitLife();
        }

        //—читаем дистанцию до врага
        
        //Vector3 target = enemies[tar].transform.position;

        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            /*GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                curDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
                if (curDistance <= distance)
                {
                    distance = curDistance;
                    tar = i;
                }
            }*/
            distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
        }

        if (!isPlayerDead && distance > 8 || !GameObject.FindGameObjectWithTag("Enemy") && !isPlayerDead)
        {
            PlayerMove();
        }

        //StartCoroutine(Wait(aspd));
        if (distance <= 8 && GameObject.FindGameObjectWithTag("Enemy"))
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= aspd)
            {
                BombAtack();
                timeElapsed = 0f;
            }
        }
    }

    IEnumerator Wait2(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.bSpawn = true;
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        isPlayerDead = false;
        GameManager.Instance.bSpawn = true;
        spawnManager.SetIsMasStage(true);
        currentHealth = maxHealth;
        animator.SetBool("isDead", false);
        //speedMove = 3;
    }
    private void PlayerMove()
    {
       transform.Translate(Vector3.right * Time.deltaTime * speedMove);
    }
    private void MoveBack()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * speedMove);
    }
    private void BombAtack()
    {
        audioClips.PlayOneShot(magicSpell, 1.0f);
        Instantiate(bomb, transform.position, bomb.transform.rotation);
    }

    private void TransitLife()
    {
        MoveBack();
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        GameManager.Instance.bSpawn = false;
        isPlayerDead = true;
        spawnManager.SetIsMasStage(false);
        animator.SetBool("isDead", true);
        StartCoroutine(Wait(2));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyCounter++;
            Debug.Log(enemyCounter);
        }
    }
}
