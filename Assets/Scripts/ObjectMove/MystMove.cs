using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MystMove : MonoBehaviour
{
    [SerializeField] private float mystMoveSpeed;
    private Vector3 startMystPosition;
    private float repeatWidth;
    private void Start()
    {
        //mystMoveSpeed = 1;
        startMystPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x * 2;
    }
    private void Update()
    {
        transform.Translate(Vector3.left * mystMoveSpeed * Time.deltaTime, Space.World);
        if (transform.position.x < startMystPosition.x - repeatWidth)
        {
            transform.position = startMystPosition;
        }
    }
}
