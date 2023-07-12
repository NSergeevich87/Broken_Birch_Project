using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public ParticleSystem particleBossAttack;

    private Player player;

    public float bossDamageFrequensy = 0.3f;
    public float bossDamage = 0.1f;
    void Start()
    {
        InvokeRepeating("PlayerTakeDamage", 0, bossDamageFrequensy);
        player = GameObject.Find("Player").GetComponent<Player>();
        particleBossAttack.Pause();
    }

    void Update()
    {

    }

    public void PlayerTakeDamage()
    {
        if(transform.position.x == 0)
        {
            particleBossAttack.Play();
            player.currentHealth -= bossDamage;
        }
    }
}
