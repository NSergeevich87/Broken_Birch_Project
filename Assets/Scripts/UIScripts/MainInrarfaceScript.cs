using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainInrarfaceScript : MonoBehaviour
{
    private AudioSource audioClips;
    public AudioClip clickClip;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI powText;
    private int gold;

    public TextMeshProUGUI priceAtkText;

    private void Awake()
    {
        audioClips = GetComponent<AudioSource>();

        gold = GameManager.Instance.gold;
        goldText.text = gold.ToString();

        powText.text = "POWER " + Math.Round((GameManager.Instance.playerAtk * (1 / GameManager.Instance.playerAspd)) + GameManager.Instance.playerHp, 2) + "K";
        attackText.text = "ATK\n" + Math.Round(GameManager.Instance.playerAtk, 1);
        hpText.text = "HP\n" + Math.Round(GameManager.Instance.playerHp, 1);
        attackSpeedText.text = "ASPD\n" + Math.Round((1 / GameManager.Instance.playerAspd), 2);
    }
    private void Update()
    {
        goldText.text = GameManager.Instance.gold.ToString();
        priceAtkText.text = "UPD\n" + GameManager.Instance.priceAtk.ToString();

        powText.text = "POWER " + Math.Round((GameManager.Instance.playerAtk * (1 / GameManager.Instance.playerAspd)) + GameManager.Instance.playerHp, 2) + "K";
        attackText.text = "ATK\n" + Math.Round(GameManager.Instance.playerAtk, 1);
        hpText.text = "HP\n" + Math.Round(GameManager.Instance.playerHp, 1);
        attackSpeedText.text = "ASPD\n" + Math.Round((1 / GameManager.Instance.playerAspd), 2);
    }
    public void BackToMainMenu()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(0);
    }
    public void addAtk()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= GameManager.Instance.priceAtk)
        {
            //сколько прибавить
            GameManager.Instance.playerAtk += 5;
            GameManager.Instance.gold -= GameManager.Instance.priceAtk;
            //увеличиваем стоимость
            GameManager.Instance.priceAtk += 5;
        }
    }
    public void addHp()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerHp += 15;
            GameManager.Instance.gold -= 100;
        }
    }
    public void addAspd()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerAspd -= (GameManager.Instance.playerAspd / 100);
            GameManager.Instance.gold -= 100;
        }
    }
    public void PlaySound()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
    }
}
