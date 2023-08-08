using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private Vector3 startPos;
    public double speedMove;
    private double repeatWidth;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.parallaxMove == false)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime, Space.World);

            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
