using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public ParticleSystem particleBossAttack;

    private Player player;

    public float bossASPD;
    public float bossATK;
    void Start()
    {
        bossASPD = GameManager.Instance.bossASPD;
        bossATK = GameManager.Instance.bossATK;

        InvokeRepeating("PlayerTakeDamage", 0, bossASPD);
        player = GameObject.Find("Player").GetComponent<Player>();
        particleBossAttack.Pause();
    }

    void Update()
    {

    }

    public void PlayerTakeDamage()
    {
        if(transform.position.x == 2)
        {
            particleBossAttack.Play();
            player.currentHealth -= bossATK;
        }
    }
}
