using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionBomb;

    private Rigidbody bombRb;
    //private SpawnManager spawnManager;
    private GameObject enemy;

    [SerializeField] private float speedYmin = 7;
    [SerializeField] private float torqueMod = 10;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        direction = enemy.transform.position - transform.position;
        direction = direction.normalized;
        //transform.Translate(direction * speedYmin * Time.deltaTime);

        //bombRb.AddForce(enemy.transform.position - bombRb.transform.position, ForceMode.Impulse);
        explosionBomb.Pause();
        Invoke("AktivateBomb", 0);
        bombRb = GetComponent<Rigidbody>();

        bombRb.AddForce(RandomUpSpeed(), ForceMode.Impulse);
        bombRb.AddTorque(0, 0, TorqueMod(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomUpSpeed()
    {
        return direction * speedYmin;
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
