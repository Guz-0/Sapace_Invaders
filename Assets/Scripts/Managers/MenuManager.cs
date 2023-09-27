using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{


    public void LoadScene(string name)
    {
        Time.timeScale = 1f;
        StartCoroutine(SceneManagerScript.Instance.LoadScene(name));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

    
    
}
