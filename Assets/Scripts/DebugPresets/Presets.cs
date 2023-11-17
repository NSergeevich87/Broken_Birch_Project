using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Presets : MonoBehaviour
{
    public TMP_InputField setHealth;
    public TMP_InputField setAtk;
    public TMP_InputField setAtkSpeed;
    public TMP_InputField setStartGold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string inputHealth = setHealth.text;
        float.TryParse(inputHealth, out GameManager.Instance.playerHp); //float.Parse(inputHealth);
        string inputAtk = setAtk.text;
        float.TryParse(inputAtk, out GameManager.Instance.playerAtk);
        //GameManager.Instance.playerAtk = float.Parse(inputAtk);
        string inputSpeedAtk = setAtkSpeed.text;
        float.TryParse(inputSpeedAtk, out GameManager.Instance.playerAspd);
        //GameManager.Instance.playerAspd = float.Parse(inputSpeedAtk);
        string inputGoldStart = setStartGold.text;
        int.TryParse(inputGoldStart, out GameManager.Instance.gold);
        //GameManager.Instance.gold = int.Parse(inputGoldStart);
    }
}
