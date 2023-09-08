using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainInrarfaceScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI powText;
    private int gold;
    
    private void Awake()
    {
        gold = GameManager.Instance.gold;
        goldText.text = gold.ToString();

        powText.text = "POW: " + Math.Round((GameManager.Instance.playerAtk * (1 / GameManager.Instance.playerAspd)) + GameManager.Instance.playerHp, 2);
        attackText.text = "ATK: " + Math.Round(GameManager.Instance.playerAtk, 1);
        hpText.text = "HP: " + Math.Round(GameManager.Instance.playerHp, 1);
        attackSpeedText.text = "ASPD: " + Math.Round(GameManager.Instance.playerAspd, 2);
    }
    private void Update()
    {
        goldText.text = GameManager.Instance.gold.ToString();

        powText.text = "POW: " + Math.Round((GameManager.Instance.playerAtk * (1 / GameManager.Instance.playerAspd)) + GameManager.Instance.playerHp, 2);
        attackText.text = "ATK: " + Math.Round(GameManager.Instance.playerAtk, 1);
        hpText.text = "HP: " + Math.Round(GameManager.Instance.playerHp, 1);
        attackSpeedText.text = "ASPD: " + Math.Round(GameManager.Instance.playerAspd, 2);
    }
    public void BackToMainMenu()
    {
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(0);
    }
    public void addAtk()
    {
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerAtk += 5;
            GameManager.Instance.gold -= 100;
        }
    }
    public void addHp()
    {
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerHp += 15;
            GameManager.Instance.gold -= 100;
        }
    }
    public void addAspd()
    {
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerAspd -= (GameManager.Instance.playerAspd / 100);
            GameManager.Instance.gold -= 100;
        }
    }
}
