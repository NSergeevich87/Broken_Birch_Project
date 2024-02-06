using System.IO;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour
{
    private AudioSource audioClips;
    public AudioClip Enemy_Kill;
    public AudioClip Coins_Take;

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
    public float enemyMoy;
    //Enemy boss variables
    public float enemyBossMaxHealth;
    public float bossATK;
    public float bossASPD;
    public float bossSPD;
    public float bossMoy;

    //Если босс умер увеличиваем характеристики врагам
    public bool isShouldUpStats = false;
    public float CoefficientOfUpStats = 2.0f;
    public float EnemyGoldUp = 1.02f;

    //Стоимость апгрейда
    public float priceHp = 100;
    public float priceAtk = 100;
    public float priceAspd = 100;

    //Коэффициент удорожания в %
    public float HpUp = 2.5f;
    public float PriceHpUp = 5;
    public float AtkUp = 2.5f;
    public float PriceAtkUp = 5;
    public float PriceAspdUp = 50;

    //Разрешен ли спавн
    public bool bSpawn;

    //Click counter
    public int hpClick = 0;
    public int atkClick = 0;
    public int aspdClick = 0;

    private void Awake()
    {
        bSpawn = true;
        //Screen.SetResolution(768, 1366, false);

        audioClips = GetComponent<AudioSource>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        LoadData();
        //Debug.Log(playerAtk + " " + playerHp + " " + playerAspd);

        /*if (playerHp == 0)
        {
            playerAtk = hero1.playerATK;
            playerHp = hero1.playerHP;
            playerAspd = hero1.playerASPD;
        }
        if (level == 0)
        {
            level = 1;
        }*/


        //Player variables
        playerHp = 100;
        playerAtk = 35;
        playerAspd = 1.0f;

        gold = 0;
        //level progress
        level = 1;
        stage = 1;
        //Enemy variables
        enemyMaxHealth = 50;
        enemyATK = 5;
        enemyASPD = 1.0f;
        enemySPD = 0.5f;
        enemyMoy = 125;
        //Enemy boss variables
        enemyBossMaxHealth = 700;
        bossATK = 20;
        bossASPD = 1.0f;
        bossSPD = 0.5f;
        bossMoy = 1000;
        //coeff
        CoefficientOfUpStats = 2.0f;
        EnemyGoldUp = 1.02f;
        //upps
        HpUp = 2.5f;
        PriceHpUp = 5;
        AtkUp = 2.5f;
        PriceAtkUp = 5;
        PriceAspdUp = 50;
}

    public void EnemyStatsUp()
    {
        enemyMaxHealth *= CoefficientOfUpStats;
        enemyATK *= CoefficientOfUpStats;
        enemyASPD /= 1.1f;
        enemyMoy *= EnemyGoldUp;

        enemyBossMaxHealth *= CoefficientOfUpStats;
        bossATK *= CoefficientOfUpStats;
        bossASPD /= 1.1f;
        bossMoy *= EnemyGoldUp;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(enemyMaxHealth + " " + enemyATK + " " + enemyASPD + " " + enemyMoy);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(enemyBossMaxHealth + " " + bossATK + " " + bossASPD + " " + bossMoy);
        }
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

    public void PlaySoundEnemyDeath()
    {
        audioClips.PlayOneShot(Enemy_Kill, 1.0f);
    }

    public void PlaySoundCoinsTake()
    {
        StartCoroutine(WaitSomeTime(0.65f, false));
    }

    public void PlaySoundCoinsTakeBoss()
    {
        StartCoroutine(WaitSomeTime(0.65f, true));
    }

    IEnumerator WaitSomeTime(float time, bool bBoss)
    {
        yield return new WaitForSeconds(time);
        if (!bBoss)
        {
            audioClips.PlayOneShot(Coins_Take, 1.0f);
            gold += enemyMoy;
        }
        else
        {
            audioClips.PlayOneShot(Coins_Take, 1.0f);
            gold += bossMoy;
        }
    }
}
