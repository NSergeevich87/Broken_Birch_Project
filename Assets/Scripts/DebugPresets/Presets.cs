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

    // LevelEnd statsUp of enemies
    public TMP_InputField setEnemiesUpCoefficient;
    public TMP_InputField setGoldUpFromEnemies;

    //Значения прибавления характеристик
    public TMP_InputField setHpUp;
    public TMP_InputField setAtkUp;
    //Значения удорожания
    public TMP_InputField setHpPriceUp;
    public TMP_InputField setAtkPriceUp;
    public TMP_InputField setAspdPriceUp;

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

    public void SaveEnemyStatsUp()
    {
        string inputCoefficientUp = setEnemiesUpCoefficient.text;
        float.TryParse(inputCoefficientUp, out GameManager.Instance.CoefficientOfUpStats);
        string inputGoldUpFromEnemy = setGoldUpFromEnemies.text;
        int.TryParse(inputGoldUpFromEnemy, out GameManager.Instance.EnemyGoldUp);
    }

    public void SavePlayerStatsUp()
    {
        string inputHpUp = setHpUp.text;
        float.TryParse(inputHpUp, out GameManager.Instance.HpUp);
        string inputAtkUp = setAtkUp.text;
        float.TryParse(inputAtkUp, out GameManager.Instance.AtkUp);
    }

    public void SavePlayerPriceUp()
    {
        string inputHpPrice = setHpPriceUp.text;
        float.TryParse(inputHpPrice, out GameManager.Instance.PriceHpUp);
        string inputAtkPrice = setAtkPriceUp.text;
        float.TryParse(inputAtkPrice, out GameManager.Instance.PriceAtkUp);
        string inputAspdPrice = setAspdPriceUp.text;
        float.TryParse(inputAspdPrice, out GameManager.Instance.PriceAspdUp);
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
        //Коэффициент усиливающий противников с каждым уровнем
        GameManager.Instance.CoefficientOfUpStats = 1.1f;
        GameManager.Instance.EnemyGoldUp = 5;
        //Насколько в процентном соотношении от предыдущего числа будут увеличиваться характеристики после каждого нажатия
        GameManager.Instance.HpUp = 5;
        GameManager.Instance.AtkUp = 5;
        //Насколько в процентном соотношении от предыдущего числа будет увеличиваться цена после каждого нажатия
        GameManager.Instance.PriceHpUp = 5;
        GameManager.Instance.PriceAtkUp = 5;
        GameManager.Instance.PriceAspdUp = 5;
    }
}
