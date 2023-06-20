using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    public float speedMove = 10;
    private Vector3 startPos;
    private float midMove;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        midMove = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startPos.x + (midMove * 10)) 
        { 
            transform.position = startPos;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speedMove); 
    }
}
