using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class Menu : MonoBehaviour
{
    public GameObject panlelPause;
    public void loadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void loadMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panlelPause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        panlelPause.SetActive(false);
    }
    
    
}
