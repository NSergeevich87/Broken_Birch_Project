using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        SaveManager.Instance.SaveNewData();
        SceneManager.LoadScene(0);
    }
    public void ExitApplication()
    {
        SaveManager.Instance.SaveNewData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }
}
