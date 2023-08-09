using UnityEngine;

public class Player : MonoBehaviour
{
    private SpawnManager spawnManager;

    public UIHealthBar healthBar;
    private float maxHealth;
    public float currentHealth;

    public GameObject bomb;

    public float aspd;
    public float atk;
    void Start()
    {
        BasicHero hero = new BasicHero("Gatito", 35, 100, 0.6f);
        maxHealth = hero.playerHP;
        aspd = hero.playerASPD;
        atk = hero.playerATK;

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        InvokeRepeating("BombAtack", 0, aspd);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (spawnManager.isBossAlive == false)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void BombAtack()
    {
        if (spawnManager.isAlive || spawnManager.isBossAlive)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            GameManager.Instance.parallaxMove = true;
        }
        else if (!spawnManager.isAlive || !spawnManager.isBossAlive)
        {
            GameManager.Instance.parallaxMove = false;
        }
    }
}
