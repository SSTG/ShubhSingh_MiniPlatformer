using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManagerScript : Singleton<SceneManagerScript>
{
    public UnityEvent firstTimePlay;
    void Start()
    {
        if(!PlayerPrefs.HasKey("FirstTime"))
        firstTimePlay?.Invoke();
        PlayerPrefs.SetInt("FirstTime",1);

    }
    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void Quit()
    {
        Application.Quit();
    }
    public static void AppearWindow(GameObject window)
    {
        window.SetActive(true);
    }
    public static void DisappearWindow(GameObject window)
    {
        window.SetActive(false);
    }

}
