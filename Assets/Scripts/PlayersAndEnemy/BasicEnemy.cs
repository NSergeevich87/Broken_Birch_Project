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

    public BasicEnemy(string name = "BaseName", float atk = 25, float hp = 100, float aspd = 0.5f, float spd = 0.9f, int moy = 40) 
        : base(name, atk, hp, aspd, spd, moy)//base(name = "BaseName", atk = 25, hp = 100, aspd = 0.5f, spd = 0.9f, moy = 40)
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
