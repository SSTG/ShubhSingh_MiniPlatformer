using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManagerScript : Singleton<SceneManagerScript>
{
    public UnityEvent firstTimePlay;
    public UnityEvent notFirstTimePlay;
    void Start()
    {
        

    }
    public void isFirstTimePlay()
    {
        if(!PlayerPrefs.HasKey("HighScore1"))
        firstTimePlay?.Invoke();
        else
        notFirstTimePlay?.Invoke();
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
