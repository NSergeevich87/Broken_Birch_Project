using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract
{
    private string name = "NoName";
    private float atk;  //���� �� ����� ����� 35
    private float hp;   //����� �������� 100
    private float aspd; //�������� ����� 0,6
    private double spd;  //�������� ������������
    private double pow;  //����� ���� 149 (eDPS + eHP)
    
    public PlayerAbstract(string name, float atk, float hp, float aspd)
    {
        this.name = name;
        this.atk = atk;
        this.hp = hp;
        this.aspd = aspd;
    }
    public PlayerAbstract(string name, float atk, float hp, float aspd, double spd, double pow)
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
    public float playerATK
    {
        get { return atk; }
        set { atk = value; }
    }
    public float playerHP
    {
        get { return hp; }
        set { hp = value; }
    }
    public float playerASPD
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
/*
    public abstract void attack();
    public abstract void move();*/
}
