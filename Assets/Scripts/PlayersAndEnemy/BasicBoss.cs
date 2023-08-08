using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : EnemyAbstract
{
    private string classEnemy = "cultista mayor";
    private float atk;
    private float hp;
    private float aspd;
    private int moy;

    /*
     * IDC
     * кол-во предметов 3
     * тип предмета 1А,2А,3А
     * вероятность выпадения 0.2,0.4,0.5
    */

    private int numItems;
    private string tipoItem;
    private float probCaida;

    public BasicBoss(string name, float atk, float hp, float aspd, int moy) : base(name, atk, hp, aspd, moy)
    {
        this.classEnemy = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.moy = moy;
    }

    public int NumItems
    {
        get { return numItems; }
        set { numItems = value; }
    }
    public string TipoItem
    {
        get { return tipoItem; }
        set { tipoItem = value; }
    }
    public float ProbCaida
    {
        get { return probCaida; }
        set { probCaida = value; }
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
