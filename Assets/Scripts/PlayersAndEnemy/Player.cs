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
    [SerializeField] private float speedMove;
    private float timeElapsed = 0f;

    private bool isPlayerDead;
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
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
        }

        if (!isPlayerDead && distance > 6 || !GameObject.FindGameObjectWithTag("Enemy") && !isPlayerDead)
        {
            PlayerMove();
        }
        
        //StartCoroutine(Wait(aspd));
        if (distance <= 6 && GameObject.FindGameObjectWithTag("Enemy"))
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= aspd)
            {
                BombAtack();
                timeElapsed = 0f;
            }
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        isPlayerDead = false;
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
        isPlayerDead = true;
        spawnManager.SetIsMasStage(false);
        animator.SetBool("isDead", true);
        StartCoroutine(Wait(2));
    }
}
