using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBoss : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI levelProgressText;
    private SpawnManager spawnManager;

    //public bool callBoss = false;

    private int level;
    private int stage;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        level = GameManager.Instance.level;
        stage = GameManager.Instance.stage;

        slider.maxValue = 9;
        slider.value = 0;
    }

    void Update()
    {
        levelProgressText.text = $"{GameManager.Instance.level} - {GameManager.Instance.stage}";
        slider.value = GameManager.Instance.stage - 1;

        /*if (GameManager.Instance.stage == 9 && GameManager.Instance.isBossDead)
        {
            callBoss = true;
            spawnManager.isBossAlive = true;
        }*/
    }
}
