using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speedMove = 10;
    private Vector3 startPos;
    private float midMove;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
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
        if (playerControllerScript.readyToRun == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedMove);
        }
    }
}
