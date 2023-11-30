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
    private float gold;
    //Текст изменения цены
    public TextMeshProUGUI priceAtkText;
    public TextMeshProUGUI priceHpText;
    public TextMeshProUGUI priceAspdText;

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
        goldText.text = Math.Round(GameManager.Instance.gold, 0).ToString();
        priceAtkText.text = "UPD\n" + Math.Round(GameManager.Instance.priceAtk, 0).ToString();
        priceHpText.text = "UPD\n" + Math.Round(GameManager.Instance.priceHp, 0).ToString();
        priceAspdText.text = "UPD\n" + Math.Round(GameManager.Instance.priceAspd, 0).ToString();

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
        //уравнение роста статы 2x>2 + 35
        //рост стоимости 2x>3 - x>2 + 15
        //увеличиваем счетчик
        GameManager.Instance.atkClick++;

        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= GameManager.Instance.priceAtk)
        {
            //сколько прибавить
            GameManager.Instance.playerAtk += GameManager.Instance.playerAtk * (GameManager.Instance.AtkUp / 100);
            GameManager.Instance.gold -= GameManager.Instance.priceAtk;
            //увеличиваем стоимость
            GameManager.Instance.priceAtk += GameManager.Instance.priceAtk * (GameManager.Instance.AtkUp / 100);
        }
    }
    public void addHp()
    {
        GameManager.Instance.hpClick++;

        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= GameManager.Instance.priceHp)
        {
            GameManager.Instance.playerHp += GameManager.Instance.playerHp * (GameManager.Instance.HpUp / 100);
            GameManager.Instance.gold -= GameManager.Instance.priceHp;
            GameManager.Instance.priceHp += GameManager.Instance.priceHp * (GameManager.Instance.HpUp / 100);
        }
    }
    public void addAspd()
    {
        GameManager.Instance.aspdClick++;

        audioClips.PlayOneShot(clickClip, 1.0f);
        if (GameManager.Instance.gold >= GameManager.Instance.priceAspd)
        {
            GameManager.Instance.playerAspd -= (GameManager.Instance.playerAspd / 100);
            GameManager.Instance.gold -= GameManager.Instance.priceAspd;
            GameManager.Instance.priceAspd += GameManager.Instance.priceAspd * 0.05f;
        }
    }
    public void PlaySound()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
    }
}
