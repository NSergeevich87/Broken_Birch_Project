using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Ниже описываем переменные данные которых будем сохранять
    public bool parallaxMove;
    public bool isBoss = false;

    private string playerName = "Gatito";
    public float playerAtk;
    public float playerHp;
    public float playerAspd;

    public int gold;
    //level progress
    public int level;
    public int stage;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        LoadData();
        Debug.Log(playerAtk + " " + playerHp + " " + playerAspd);
        //playerAtk = 350;
        //RESET ALL
        /*playerAtk = hero1.playerATK;
        playerHp = hero1.playerHP;
        playerAspd = hero1.playerASPD;
        level = 1;
        stage = 0;
        gold = 0;*/

        if (playerHp == 0)
        {
            playerAtk = hero1.playerATK;
            playerHp = hero1.playerHP;
            playerAspd = hero1.playerASPD;
        }
        if (level == 0)
        {
            level = 1;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public float atk;
        public float hp;
        public float aspd;

        public int gold;

        public int level;
        public int stage;
    }
    public void SaveNewData()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.atk = playerAtk;
        data.hp = playerHp;
        data.aspd = playerAspd;
        data.gold = gold;
        data.level = level;
        data.stage = stage;
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
            name = data.name;
            playerAtk = data.atk;
            playerHp = data.hp;
            playerAspd = data.aspd;
            gold = data.gold;
            level = data.level;
            stage = data.stage;
        }
    }
}
