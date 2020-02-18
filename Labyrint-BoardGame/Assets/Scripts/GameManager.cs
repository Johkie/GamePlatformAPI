using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject PauseMenuUI;
    public GameObject InGameUI;
    public GameObject GameOverMenuUI;

    private bool isGameRunning;

    private float startTime = 120;
    private float timeLeft;

    void Awake()
    {
        isGameRunning = false;

        if (MainMenuUI.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            timeLeft = startTime;
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

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GameOver();
            }
        }
    }

    public void ModifyTime(float seconds)
    {
        timeLeft += seconds;
    }

    public int GetCurrentTime()
    {
        return (int)(timeLeft + 1);
    }

    public void StartGame()
    {
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
        isGameRunning = true;
        timeLeft = startTime;
        FindObjectOfType<ObstacleManager>().RandomObstacles(0);
    }

    public void ResumeGame()
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        InGameUI.SetActive(false);
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGameRunning = false;
    }

    public void ExitGame()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
