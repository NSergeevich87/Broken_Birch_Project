using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Ниже описываем переменные данные которых будем сохранять
    public string playerName = "Gatito";
    public bool parallaxMove;

    public float playerATK;
    public float playerHP;
    public float playerASPD;

    public float enemyATK;
    public float enemyHP;
    public float enemyASPD;
    public int enemyGold;

    public float bossATK;
    public float bossHP;
    public float bossASPD;
    public int bossGold;

    private void Awake()
    {
        BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        playerATK = hero1.playerATK;
        playerHP = hero1.playerHP;
        playerASPD = hero1.playerASPD;
        Debug.Log(playerATK + " " + playerHP + " " + playerASPD);
        BasicEnemy enemy1 = new BasicEnemy("cultista simple", 25, 100, 0.5f, 40);
        enemyATK = enemy1.enemyATK;
        enemyHP = enemy1.enemyHP;
        enemyASPD = enemy1.enemyASPD;
        enemyGold = enemy1.enemyMOY;
        Debug.Log(enemyATK + " " + enemyHP + " " + enemyASPD + " " + enemyGold);
        BasicBoss boss1 = new BasicBoss("cultista mayor", 40, 2000, 0.5f, 250);
        bossATK = boss1.enemyATK; 
        bossHP = boss1.enemyHP;
        bossASPD = boss1.enemyASPD;
        bossGold = boss1.enemyMOY;
        Debug.Log(bossATK + " " + bossHP + " " + bossASPD + " " + bossGold);

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
    }
    public void SaveNewData()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData() 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.name;
        }
    }
}
