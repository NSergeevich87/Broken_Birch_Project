using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainInrarfaceScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private int gold;
    private void Start()
    {
        gold = GameManager.Instance.gold;
        goldText.text = gold.ToString();
    }
    private void Update()
    {
        goldText.text = GameManager.Instance.gold.ToString();
    }
    public void BackToMainMenu()
    {
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(0);
    }
    public void addAtk()
    {
        /*if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerAtk += 5;
            GameManager.Instance.gold -= 100;
        }*/
    }
    public void addHp()
    {
        /*if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerHp += 15;
            GameManager.Instance.gold -= 100;
        }*/
    }
    public void addAspd()
    {
        /*if (GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.playerAspd -= (GameManager.Instance.playerAspd / 100);
            GameManager.Instance.gold -= 100;
        }*/
    }
}
