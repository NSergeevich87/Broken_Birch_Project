using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private Player player;

    private Vector3 startPos;

    public float speedMove;

    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.stopParallaxMove == false)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime, Space.World);

            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
