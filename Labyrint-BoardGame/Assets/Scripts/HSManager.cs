using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSManager : MonoBehaviour
{
    public HSItemUI[] hsItems;

    public void Awake()
    {
        hsItems = GetComponentsInChildren<HSItemUI>();
        ClearBoard();

        FindObjectOfType<WebAPI>().highScoreUpdateCallback = UpdateHighscore;
        FindObjectOfType<WebAPI>().UpdateHighScore();    
    }

    private void ClearBoard()
    {
        if (hsItems.Length != 0)
        {
            hsItems[0].AssignHSItem("", 0);
            hsItems[1].AssignHSItem("", 0);
            hsItems[2].AssignHSItem("", 0);
            hsItems[3].AssignHSItem("", 0);
            hsItems[4].AssignHSItem("", 0);
        }
    }
    public void UpdateHighscore(List<HSItem> items)
    {
        if (hsItems.Length != 0)
        {
            ClearBoard();
            for (int i = 0; i < items.Count; i++)
            {
                hsItems[i].AssignHSItem(items[i].user, items[i].score);
            }
        }
    }
}
