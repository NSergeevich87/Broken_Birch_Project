using System;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float stopPos;
    void Start()
    {
        stopPos = 2;
    }
    void Update()
    {
        var pos = transform.localPosition;
        pos.x = Mathf.MoveTowards(pos.x, stopPos, Time.deltaTime);
        transform.localPosition = pos;
    }
}
