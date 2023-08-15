using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public UIHealthBar healthBar;
    private float maxHealth;
    public float currentHealth;

    public GameObject bomb;

    private float aspd;
    public float atk { get; private set; }

    private float distance = 10;
    [SerializeField] private float speedMove;
    private float timeElapsed = 0f;
    void Start()
    {
        maxHealth = GameManager.Instance.playerHp;
        aspd = GameManager.Instance.platerAspd;
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

        Debug.Log(atk + " " + maxHealth + " " + aspd);
        //јвто–еген ’ѕ
        if (currentHealth < maxHealth)
        {
            currentHealth += (maxHealth * 0.02f) * Time.deltaTime;
        }

        healthBar.SetHealth(currentHealth);
        maxHealth = GameManager.Instance.playerHp;
        aspd = GameManager.Instance.platerAspd;
        atk = GameManager.Instance.playerAtk;

        if (currentHealth <= 0)
        {
            GameManager.Instance.stage = 1;
            SceneManager.LoadScene(1);
        }

        //—читаем дистанцию до врага
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
        }

        if (distance > 6 || !GameObject.FindGameObjectWithTag("Enemy"))
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
        speedMove = 3;
    }
    public void PlayerMove()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedMove);
    }
    private void BombAtack()
    {
        Instantiate(bomb, transform.position, bomb.transform.rotation);
    }
}
