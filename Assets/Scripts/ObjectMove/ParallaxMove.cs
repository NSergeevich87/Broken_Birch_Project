using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private Vector3 startPos;
    public float speedMove;
    private float repeatWidth;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }
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
