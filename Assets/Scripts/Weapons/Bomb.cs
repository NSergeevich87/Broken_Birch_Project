using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionBomb;

    private Rigidbody2D bombRb;
    //private SpawnManager spawnManager;

    [SerializeField] private float speedYmin = 4;
    [SerializeField] private float torqueMod;// = 10;

    private Vector3 norTar;

    private float distance = 200;
    int tar;
    void Start()
    {
        float curDistance;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            curDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (curDistance <= distance)
            {
                distance = curDistance;
                tar = i;
            }
        }
        Vector3 target = enemies[tar].transform.position;

        //enemy = GameObject.FindGameObjectWithTag("Enemy");

        //Vector3 target = FindEnemy();//enemy.transform.position;
        norTar = (target - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;

        //spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        ////direction = (enemy.transform.position - transform.position).normalized;
        //direction = direction.normalized;
        //transform.Translate(direction * speedYmin * Time.deltaTime);

        //bombRb.AddForce(enemy.transform.position - bombRb.transform.position, ForceMode.Impulse);
        explosionBomb.Pause();
        Invoke("AktivateBomb", 0);
        bombRb = GetComponent<Rigidbody2D>();

        bombRb.AddForce(RandomUpSpeed(), ForceMode2D.Impulse);
        //bombRb.AddTorque(0, 0, TorqueMod(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            Destroy(gameObject, 5);
        }

        //===========================
        
    }

    Vector3 RandomUpSpeed()
    {
        return norTar * speedYmin;
    }

    float TorqueMod()
    {
        return Random.Range(-torqueMod, torqueMod);
    }


    void AktivateBomb()
    {
        explosionBomb.Play();
    }
}
