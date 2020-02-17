using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenuUI;

    void Awake()
    {
        if (MainMenuUI.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
