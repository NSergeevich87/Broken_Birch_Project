using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private Vector3 startPos;

    public float speedMove;

    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speedMove * Time.deltaTime, Space.World);
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
