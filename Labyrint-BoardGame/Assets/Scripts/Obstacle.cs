using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [HideInInspector] public int timeModifier;
    [HideInInspector] public int scoreModifier;

    public bool isGoodObstacle;
    public bool isStatic;
    public bool isAlwaysBad;

    public Material material;

    private void Awake()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    public void OnCollisionEnter(Collision collision)
    {
        ObstacleManager om = FindObjectOfType<ObstacleManager>();
        FindObjectOfType<GameLogic>().ModifyScore((int)(scoreModifier * om.CalculatePointDecay()));
        FindObjectOfType<GameManager>().ModifyTime(timeModifier);

        if (isGoodObstacle)
        {
            om.RandomObstacles(6);
            om.timeSinceLastHit = 0;
        }
    }
}
