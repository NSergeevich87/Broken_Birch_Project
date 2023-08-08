using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //public ParticleSystem particleBossAttack;

    private Player player;

    public float enemyASPD;
    public float enemyATK;
    void Start()
    {
        enemyASPD = GameManager.Instance.enemyASPD;
        enemyATK = GameManager.Instance.enemyATK;

        player = GameObject.Find("Player").GetComponent<Player>();
        InvokeRepeating("PlayerTakeDamage", 0, enemyASPD);
        //particleBossAttack.Pause();
    }

    void Update()
    {

    }

    public void PlayerTakeDamage()
    {
        if (transform.position.x == 2)
        {
            //particleBossAttack.Play();
            player.currentHealth -= enemyATK;
        }
    }
}
