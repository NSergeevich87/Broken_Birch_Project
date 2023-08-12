using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private int SceneNum;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitGame()
    {
        GameManager.Instance.SaveNewData();
        SceneManager.LoadScene(SceneNum);
    }
    public void ExitApplication()
    {
        GameManager.Instance.SaveNewData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
