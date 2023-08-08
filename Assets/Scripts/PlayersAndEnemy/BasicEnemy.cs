using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyAbstract
{
    private string classEnemy = "cultista simple";
    private float atk;
    private float hp;
    private float aspd;
    private int moy;

    public BasicEnemy(string name, float atk, float hp, float aspd, int moy) : base(name, atk, hp, aspd, moy)
    {
        this.classEnemy = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.moy = moy;
    }

    public override void attack()
    {
        throw new System.NotImplementedException();
    }

    public override void move()
    {
        throw new System.NotImplementedException();
    }
}
