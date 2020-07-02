using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuSettings : MonoBehaviour
{


    private void Start()
    {
           
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
           
        }
    }
}
