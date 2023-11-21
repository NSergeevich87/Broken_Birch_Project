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
    //���� ��������� ���������� ������ ������� ����� ���������
    public bool parallaxMove;
    public bool isBoss = false;

    private string playerName = "Gatito";
    //Player variables
    public float playerHp = 100;
    public float playerAtk = 35;
    public float playerAspd = 0.6f;

    public int gold = 0;
    //level progress
    public int level = 1;
    public int stage = 1;
    //Enemy variables
    public float enemyMaxHealth = 100;
    public float enemyATK = 25;
    public float enemyASPD = 0.5f;
    public float enemySPD = 0.9f;
    public int enemyMoy = 40;
    //Enemy boss variables
    public float enemyBossMaxHealth = 2000;
    public float bossATK = 40;
    public float bossASPD = 0.5f;
    public float bossSPD = 1;
    public int bossMoy = 250;

    private void Awake()
    {
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

    public void PlayClip()
    {
        audioClips.PlayOneShot(clipCoins, 1.0f);
    }
}
