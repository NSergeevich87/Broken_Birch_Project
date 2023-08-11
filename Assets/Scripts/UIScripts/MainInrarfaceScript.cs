using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainInrarfaceScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private int gold;
    private void Start()
    {
        gold = GameManager.Instance.gold;
        goldText.text = gold.ToString();
    }
    private void Update()
    {
        goldText.text = GameManager.Instance.gold.ToString();
    }
    public void BackToMainMenu()
    {
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(0);
    }
}
