using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

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

    // Level and Stage presets
    public TMP_InputField setLVL;
    public TMP_InputField setStage;

    public void SaveCharacterPresets()
    {
        string inputHealth = setHealth.text;
        float.TryParse(inputHealth, out GameManager.Instance.playerHp); 
        string inputAtk = setAtk.text;
        float.TryParse(inputAtk, out GameManager.Instance.playerAtk);
        string inputSpeedAtk = setAtkSpeed.text;
        float.TryParse(inputSpeedAtk, out GameManager.Instance.playerAspd);
        string inputGoldStart = setStartGold.text;
        float.TryParse(inputGoldStart, out GameManager.Instance.gold);
    }

    public void SaveEnemyPresets()
    {
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
    }

    public void SaveBossPresets()
    {
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

    public void SaveLevelPresets()
    {
        string inputLVL = setLVL.text;
        int.TryParse(inputLVL, out GameManager.Instance.level);
        string inputStage = setStage.text;
        int.TryParse(inputStage, out GameManager.Instance.stage);
    }

    public void ResetToDefaultPresets()
    {
        //Player variables
        GameManager.Instance.playerHp = 100;
        GameManager.Instance.playerAtk = 35;
        GameManager.Instance.playerAspd = 0.6f;

        GameManager.Instance.gold = 0;
        //level progress
        GameManager.Instance.level = 1;
        GameManager.Instance.stage = 0;
        //Enemy variables
        GameManager.Instance.enemyMaxHealth = 100;
        GameManager.Instance.enemyATK = 25;
        GameManager.Instance.enemyASPD = 0.5f;
        GameManager.Instance.enemySPD = 0.9f;
        GameManager.Instance.enemyMoy = 40;
        //Enemy boss variables
        GameManager.Instance.enemyBossMaxHealth = 2000;
        GameManager.Instance.bossATK = 40;
        GameManager.Instance.bossASPD = 0.5f;
        GameManager.Instance.bossSPD = 1;
        GameManager.Instance.bossMoy = 250;
    }
}
