using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private string userName;
    private int userScore;

    public TextMeshProUGUI ScoreText;
    public TMP_InputField UserInput;
    public Button PostButton;

    public void OnEnable()
    {
        userScore = FindObjectOfType<GameLogic>().GetScore();
        ScoreText.text = userScore.ToString();    
    }

    public void TryToPostHighscore()
    {
        if(UserInput.text != string.Empty)
        {
            userName = UserInput.text;
            FindObjectOfType<WebAPI>().AddHighScore(new HSItem { user = userName, score = userScore });

            // Lock userinput
            UserInput.enabled = false;

            // Lock postbutton
            PostButton.enabled = false;
            PostButton.GetComponentInChildren<TextMeshProUGUI>().text = "Posted";
        }
        else
        {
            PostButton.enabled = false;
            PostButton.enabled = true;
        }

    }
}
