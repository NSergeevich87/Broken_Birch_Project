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
        //расчет расстояния между двумя объектами
        //float distance = Vector3.Distance (object1.transform.position, object2.transform.position);

        var pos = transform.localPosition;
        pos.x = Mathf.MoveTowards(pos.x, stopPos, Time.deltaTime);
        transform.localPosition = pos;
    }
}
