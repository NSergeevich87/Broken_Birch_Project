using UnityEngine;

public class Player : MonoBehaviour
{
    public bool stopParallaxMove = false;

    private SpawnManager spawnManager;

    public UIHealthBar healthBar;
    public float maxHealth = 10;
    public float currentHealth;

    public GameObject bomb;

    public float dps = 1.0f;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        InvokeRepeating("BombAtack", 0, dps);

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
            stopParallaxMove = true;
        }
        else if (!spawnManager.isAlive || !spawnManager.isBossAlive)
        {
            stopParallaxMove = false;
        }
    }
}
