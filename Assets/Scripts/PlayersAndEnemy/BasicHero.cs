using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHero : PlayerAbstract
{
    string classPlayer = "Magico";
    public BasicHero(string classPlayer, string name, double atk, double hp, double aspd) : base(name, atk, hp, aspd)
    {
        this.classPlayer = classPlayer;
        name = "GatoMago";
        atk = 35;
        hp = 100;
        aspd = 0.6;
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
