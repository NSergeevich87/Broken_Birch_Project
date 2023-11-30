using System.IO;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AudioSource audioClips;
    public AudioClip clipCoins;
    public static GameManager Instance { get; set; }
    //Ниже описываем переменные данные которых будем сохранять
    public bool parallaxMove;
    public bool isBoss = false;

    private string playerName = "Gatito";
    //Player variables
    public float playerHp;
    public float playerAtk;
    public float playerAspd;

    public float gold;
    //level progress
    public int level;
    public int stage;
    //Enemy variables
    public float enemyMaxHealth;
    public float enemyATK;
    public float enemyASPD;
    public float enemySPD;
    public int enemyMoy;
    //Enemy boss variables
    public float enemyBossMaxHealth;
    public float bossATK;
    public float bossASPD;
    public float bossSPD;
    public int bossMoy;

    //Если босс умер увеличиваем характеристики врагам
    public bool isShouldUpStats = false;
    public float CoefficientOfUpStats = 1.1f;
    public int EnemyGoldUp = 5;

    //Стоимость апгрейда
    public float priceHp = 100;
    public float priceAtk = 100;
    public float priceAspd = 100;

    //Коэффициент удорожания в %
    public float HpUp = 5;
    public float AtkUp = 2;

    //Click counter
    public int hpClick = 0;
    public int atkClick = 0;
    public int aspdClick = 0;

    private void Awake()
    {

        Screen.SetResolution(768, 1366, true);

        audioClips = GetComponent<AudioSource>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        LoadData();
        //Debug.Log(playerAtk + " " + playerHp + " " + playerAspd);

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


        //Player variables
        playerHp = 100;
        playerAtk = 35;
        playerAspd = 0.6f;

        gold = 0;
        //level progress
        level = 1;
        stage = 1;
        //Enemy variables
        enemyMaxHealth = 100;
        enemyATK = 25;
        enemyASPD = 0.5f;
        enemySPD = 0.9f;
        enemyMoy = 40;
        //Enemy boss variables
        enemyBossMaxHealth = 2000;
        bossATK = 40;
        bossASPD = 0.5f;
        bossSPD = 1;
        bossMoy = 250;
    }

    public void EnemyStatsUp()
    {
        enemyMaxHealth *= CoefficientOfUpStats;
        enemyATK *= CoefficientOfUpStats;
        enemyASPD /= CoefficientOfUpStats;
        enemyMoy += EnemyGoldUp;
    }
    private void Update()
    {
        Debug.Log(enemyMaxHealth + " " + enemyATK + " " + enemyASPD + " " + enemyMoy);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public float atk;
        public float hp;
        public float aspd;

        public float gold;

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

    public void PlayClip()
    {
        audioClips.PlayOneShot(clipCoins, 1.0f);
    }
}
