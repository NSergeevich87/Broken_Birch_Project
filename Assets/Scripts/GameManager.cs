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

    private void Awake()
    {
        BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        playerATK = hero1.playerATK;
        playerHP = hero1.playerHP;
        playerASPD = hero1.playerASPD;
        Debug.Log(playerATK + " " + playerHP + " " + playerASPD);
        
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
        public float atk;
        public float hp;
        public float aspd;
    }
    public void SaveNewData()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.atk = playerATK;
        data.hp = playerHP;
        data.aspd = playerASPD;
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
            playerATK = data.atk;
            playerHP = data.hp;
            playerASPD = data.aspd;
        }
    }
}
