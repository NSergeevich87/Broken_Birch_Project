using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionBomb;

    private Rigidbody bombRb;

    private float speedYmin = 7;
    //private float speedYmax = 5;
    private float torqueMod = 10;

    // Start is called before the first frame update
    void Start()
    {
        explosionBomb.Pause();
        Invoke("AktivateBomb", 0.15f);
        bombRb = GetComponent<Rigidbody>();
        bombRb.AddForce(RandomUpSpeed(), ForceMode.Impulse);
        bombRb.AddTorque(0, 0, TorqueMod(), ForceMode.Impulse);
        //transform.position = NewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10 || transform.position.y < -2 || transform.position.z > 7)
        {
            Destroy(gameObject);
        }
    }
    Vector3 RandomUpSpeed()
    {
        return Vector3.right * speedYmin;//Random.Range(speedYmin, speedYmax);
    }

    float TorqueMod()
    {
        return Random.Range(-torqueMod, torqueMod);
    }

    /*Vector3 NewPosition()
    {
        return new Vector3(positionX, positionY);
    }*/
    void AktivateBomb()
    {
        explosionBomb.Play();
    }
}
