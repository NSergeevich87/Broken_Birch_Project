using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    public bool readyToRun = true;
    // Start is called before the first frame update
    void Start()
    {
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
