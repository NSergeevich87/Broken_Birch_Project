using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //���� ��������� ���������� ������ ������� ����� ���������
    public bool parallaxMove;

    private string playerName = "Gatito";
    public float playerAtk;
    public float playerHp;
    public float platerAspd;

    public int gold;
    private void Awake()
    {
        BasicHero hero1 = new BasicHero(playerName, 35, 100, 0.6f);
        LoadData();

        Debug.Log(playerAtk + " " + playerHp + " " + platerAspd);

        if (playerHp == 0)
        {
            playerAtk = hero1.playerATK;
            playerHp = hero1.playerHP;
            platerAspd = hero1.playerASPD;
        }

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadData();
    }
    [System.Serializable]
    class SaveData
    {
        public string name;
        public float atk;
        public float hp;
        public float aspd;

        public int gold;
    }
    public void SaveNewData()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.atk = playerAtk;
        data.hp = playerHp;
        data.aspd = platerAspd;
        data.gold = gold;
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
            platerAspd = data.aspd;
            gold = data.gold;
        }
    }
}
