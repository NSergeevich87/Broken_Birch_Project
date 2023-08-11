using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasicHero : PlayerAbstract
{
    private string classPlayer = "magico";
    private double specialATK1 = 100;
    private double specialATK2 = 50;

    private string name;
    private float atk;
    private float hp;
    private float aspd;
    public BasicHero(string name, float atk, float hp, float aspd) : base(name, atk, hp, aspd)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
    }
    public string getClass
    {
        get { return classPlayer; }
        set { classPlayer = value; }
    }
    public double getSpecialATK1
    {
        get { return specialATK1; }
        set { specialATK1 = value; }
    }
    public double getSpecialATK2
    {
        get { return specialATK2; }
        set { specialATK2 = value; }
    }
    /*public override void attack()
    {
        
         
        throw new System.NotImplementedException();
    }

    public override void move()
    {
        throw new System.NotImplementedException();
    }*/
}
