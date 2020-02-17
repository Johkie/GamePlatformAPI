﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HSItem : MonoBehaviour
{
    private TextMeshProUGUI rankText;
    private TextMeshProUGUI userText;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        rankText = texts[0];
        userText = texts[1];
        scoreText = texts[2];
    }

    public void AssignHSItem(HSItemElement item)
    {
        userText.text = item.User;
        scoreText.text = item.Score.ToString();
    }

    public void AssignHSItem(string user, int score)
    {
        userText.text = user;
        scoreText.text = score.ToString();
    }
}
