using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract
{
    private string name = "NoName";
    private float atk; //damage from attack 25
    private float hp;  //health points 100
    private float aspd;//speed of attack 0.5c
    private float spd; //speed of move 60
    private int moy; //gold from mobe 40

    public EnemyAbstract(string name, float atk, float hp, float aspd, int moy)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.moy = moy;
    }
    public EnemyAbstract(string name, float atk, float hp, float aspd, float spd, int moy)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.spd = spd;
        this.moy = moy;
    }

    public string enemyName
    {
        get { return name; }
        set { name = value; }
    }
    public float enemyATK
    {
        get { return atk; }
        set { atk = value; }
    }
    public float enemyHP
    {
        get { return hp; }
        set { hp = value; }
    }
    public float enemyASPD
    {
        get { return aspd; }
        set { aspd = value; }
    }
    public float enemySPD
    {
        get { return spd; }
        set { spd = value; }
    }
    public int enemyMOY
    {
        get { return moy; }
        set { moy = value; }
    }

    public abstract void attack();
    public abstract void move();
}
