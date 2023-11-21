using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Presets : MonoBehaviour
{
    // Character presets
    public TMP_InputField setHealth;
    public TMP_InputField setAtk;
    public TMP_InputField setAtkSpeed;
    public TMP_InputField setStartGold;

    // Enemy presets
    public TMP_InputField setEnemyHealth;
    public TMP_InputField setEnemyAtk;
    public TMP_InputField setEnemyAtkSpeed;
    public TMP_InputField setEnemyMoveSpeed;
    public TMP_InputField setEnemyDropGold;

    // Enemy Boss presets
    public TMP_InputField setBossHealth;
    public TMP_InputField setBossAtk;
    public TMP_InputField setBossAtkSpeed;
    public TMP_InputField setBossMoveSpeed;
    public TMP_InputField setBossDropGold;

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

        string inputEnemyHP = setEnemyHealth.text;
        float.TryParse(inputEnemyHP, out GameManager.Instance.enemyMaxHealth);
        string inputEnemyAtk = setEnemyAtk.text;
        float.TryParse(inputEnemyAtk, out GameManager.Instance.enemyATK);
        string inputEnemyAtkSpeed = setEnemyAtkSpeed.text;
        float.TryParse(inputEnemyAtkSpeed, out GameManager.Instance.enemyASPD); //speed atk
        string inputEnemyMoveSpeed = setEnemyMoveSpeed.text;
        float.TryParse(inputEnemyMoveSpeed, out GameManager.Instance.enemySPD);
        string inputEnemyMoy = setEnemyDropGold.text;
        int.TryParse(inputEnemyMoy, out GameManager.Instance.enemyMoy);

        string inputBossHP = setBossHealth.text;
        float.TryParse(inputBossHP, out GameManager.Instance.enemyBossMaxHealth);
        string inputBossAtk = setBossAtk.text;
        float.TryParse(inputBossAtk, out GameManager.Instance.bossATK);
        string inputBossAtkSpeed = setBossAtkSpeed.text;
        float.TryParse(inputBossAtkSpeed, out GameManager.Instance.bossASPD); //speed atk
        string inputBossMoveSpeed = setBossMoveSpeed.text;
        float.TryParse(inputBossMoveSpeed, out GameManager.Instance.bossSPD);
        string inputBossMoy = setBossDropGold.text;
        int.TryParse(inputBossMoy, out GameManager.Instance.bossMoy);
    }
}
