using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    private int playerScore;

    public TextMeshProUGUI TimeLeftTextUI;
    public TextMeshProUGUI ScoreTextUI;

    void Start()
    {
        gm = GetComponent<GameManager>();
        playerScore = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeftTextUI.text = gm.GetCurrentTime().ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            ModifyScore(50);
        }
    }

    private void UpdateScore()
    {
        ScoreTextUI.text = playerScore.ToString();
    }

    public void ModifyScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScore();
    }

    public void ResetScore()
    {
        playerScore = 0;
        UpdateScore();
    }

    public int GetScore()
    {
        return playerScore;
    }
}
