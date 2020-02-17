using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject PauseMenuUI;
    public GameObject InGameUI;

    private bool isGameRunning;

    void Awake()
    {
        isGameRunning = false;

        if (MainMenuUI.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            StartGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    public void StartGame()
    {
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
        isGameRunning = true;
    }

    public void PauseGame()
    {
        InGameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGameRunning = false;
    }

    public void ResetGame()
    {
        InGameUI.SetActive(false);
        MainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGameRunning = false;
    }

    public void ExitGame()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
