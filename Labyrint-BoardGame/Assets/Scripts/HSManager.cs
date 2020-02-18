using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSManager : MonoBehaviour
{
    private HSItemUI[] hsItems;

    public void Awake()
    {
        hsItems = GetComponentsInChildren<HSItemUI>();
    }

    public void OnEnable()
    {
        hsItems[0].AssignHSItem("Johkie1", 2000);
        hsItems[1].AssignHSItem("Johkie2", 1900);
        hsItems[2].AssignHSItem("Assc3", 1500);
        hsItems[3].AssignHSItem("", 0);
        hsItems[4].AssignHSItem("", 0);
    }
}
