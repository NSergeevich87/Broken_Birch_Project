using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLeftMove : MonoBehaviour
{
    public float speedMove = 5;
    private float destroyObjectDistance = 70;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > destroyObjectDistance && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.left * Time.deltaTime * speedMove);
    }
}
