using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Ниже описываем переменные данные которых будем сохранять
    public string playerName;
    public bool parallaxMove;

    public float attack;

    private void Awake()
    {
        //BasicHero hero1 = new BasicHero("Gatito", 35, 100, 0.6);
        //BasicHero.hero.playerHP -= 10;
        //Debug.Log(BasicHero.hero.playerHP);

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
