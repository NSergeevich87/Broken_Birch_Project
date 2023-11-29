using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private int SceneNum;

    private AudioSource audioClips;
    public AudioClip clickClip;

    private void Start()
    {
        audioClips = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
    }
    public void StartGame()
    {
        //audioClips.PlayOneShot(clickClip, 1.0f);
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitGame()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitApplication()
    {
        audioClips.PlayOneShot(clickClip, 1.0f);
        GameManager.Instance.SaveNewData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
