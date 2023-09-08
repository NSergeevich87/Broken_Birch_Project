using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionBomb;

    private Rigidbody2D bombRb;
    //private SpawnManager spawnManager;
    private GameObject enemy;

    [SerializeField] private float speedYmin = 4;
    [SerializeField] private float torqueMod;// = 10;

    private Vector3 norTar;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        Vector3 target = enemy.transform.position;
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
