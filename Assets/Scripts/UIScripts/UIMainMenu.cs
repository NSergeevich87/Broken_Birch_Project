using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private int SceneNum;

    private AudioSource audioClips;
    public AudioClip[] clickClip;

    private void Start()
    {
        audioClips = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        int Num = UnityEngine.Random.Range(0, 2);
        audioClips.PlayOneShot(clickClip[Num], 1.0f);
    }
    public void StartGame()
    {
        GameManager.Instance.bSpawn = true;
        //audioClips.PlayOneShot(clickClip, 1.0f);
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitGame()
    {
        GameManager.Instance.bSpawn = true;
        int Num = UnityEngine.Random.Range(0, 2);
        audioClips.PlayOneShot(clickClip[Num], 1.0f);
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitApplication()
    {
        int Num = UnityEngine.Random.Range(0, 2);
        audioClips.PlayOneShot(clickClip[Num], 1.0f);
        GameManager.Instance.SaveNewData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
