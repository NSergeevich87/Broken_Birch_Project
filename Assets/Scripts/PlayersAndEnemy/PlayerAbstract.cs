using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract
{
    private string name = "NoName";
    private double atk;  //Урон от одной атаки 35
    private double hp;   //Запас здоровья 100
    private double aspd; //Скорость атаки 0,6
    private double spd;  //Скорость передвижения
    private double pow;  //Общая сила 149 (eDPS + eHP)
    
    public PlayerAbstract(string name, double atk, double hp, double aspd)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
    }
    public PlayerAbstract(string name, double atk, double hp, double aspd, double spd, double pow)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
        this.spd = spd;
        this.pow = pow;
    }
    public string playerName
    {
        get { return name; }
        set { name = value; }
    }
    public double playerATK
    {
        get { return atk; }
        set { atk = value; }
    }
    public double playerHP
    {
        get { return hp; }
        set { hp = value; }
    }
    public double playerASPD
    {
        get { return aspd; }
        set { aspd = value; }
    }
    public double playerSpeedMove
    {
        get { return spd; }
        set { spd = value; }
    }
    public double playerForce
    {
        get { return pow; }
        set { pow = value; }
    }

    public abstract void attack();
    public abstract void move();
}
