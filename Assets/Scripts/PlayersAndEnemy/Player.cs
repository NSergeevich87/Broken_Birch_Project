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

    private float distance;
    void Start()
    {
        maxHealth = GameManager.Instance.playerHp;
        aspd = GameManager.Instance.platerAspd;
        atk = GameManager.Instance.playerAtk;

        InvokeRepeating("BombAtack", 0, aspd);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Debug.Log(atk + " " + maxHealth + " " + aspd);

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
    }

    private void BombAtack()
    {
        GameManager.Instance.parallaxMove = false;

        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
            if (distance < 6)
            {
                Instantiate(bomb, transform.position, transform.rotation);
                GameManager.Instance.parallaxMove = true;
            }
        }
    }
}
