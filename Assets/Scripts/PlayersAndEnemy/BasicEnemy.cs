using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyAbstract
{
    private string classEnemy = "cultista simple";
    private float atk;
    private float hp;
    private float aspd;
    private float spd;
    private int moy;

    public BasicEnemy(string name, float atk, float hp, float aspd, float spd, int moy) : base(name, atk, hp, aspd, spd, moy)
    {
        this.classEnemy = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.spd = spd;
        this.moy = moy;
    }

    /*public override void attack()
    {
        Debug.Log("Attack Enemy");
        //throw new System.NotImplementedException();
    }

    public override void move()
    {
        var pos = transform.localPosition;
        pos.x -= spd * Time.deltaTime;
        transform.localPosition = pos;
    }*/
}
