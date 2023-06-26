using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    public bool readyToRun = true;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    public AudioClip obstacleSound;
    public AudioClip chickenSound;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("Run", true);
    }
    // Update is called once per frame
    void Update()
    {

    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(obstacleSound, 1.0f);
            playerAudio.PlayOneShot(chickenSound, 1.0f);
            explosionParticle.Play();
            playerAnim.SetBool("Eat", true);
            Destroy(collision.gameObject);
            Invoke("eatStop", 0.5f);
            readyToRun = false;

        }
    }

    public void eatStop()
    {
        playerAnim.SetBool("Eat", false);
        readyToRun = true;
    }
}
