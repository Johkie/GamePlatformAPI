using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ObstacleDelegate(Obstacle o);

public class ObstacleManager : MonoBehaviour
{
    private float maxPercentOfRedObstacles = 10;

    public Material greenMaterial;
    public Material redMaterial;
    public Material blackMaterial;

    private List<ObstacleDelegate> obstacleRandomizer = new List<ObstacleDelegate>();
    private Obstacle[] obstacles;
    private Obstacle previousGreenObstacle;

    public float timeSinceLastHit;

    void Start()
    {
        obstacleRandomizer.Add(BadObstacle);
        obstacleRandomizer.Add(GoodObstacle);
        obstacleRandomizer.Add(NeutralObstacle);

        obstacles = FindObjectsOfType<Obstacle>();
        previousGreenObstacle = obstacles[0];

        // Sort out all static obstacles
        List<Obstacle> temp = new List<Obstacle>();
        foreach (var o in obstacles)
        {
            if (!o.isStatic)
            {
                // Assign alwaysbad obstacles to correct values, add the rest to array
                if (o.isAlwaysBad)
                {
                    BadObstacle(o);
                }
                else
                {
                    temp.Add(o);
                }
            }
        }
        obstacles = temp.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastHit += Time.deltaTime;
    }

    public void RandomObstacles(int badObstacleIncrease)
    {
        List<ObstacleDelegate> tempList = new List<ObstacleDelegate>(obstacleRandomizer);
        maxPercentOfRedObstacles += badObstacleIncrease;

        // Max number of green obstacles
        int currentGreenObstacles = 0;
        int maxGoodObstacles = 1;

        // Max number of red obstacles
        int currentRedObstacles = 0;
        int maxRedObstalces = (int)(obstacles.Length * (maxPercentOfRedObstacles / 100));
        maxRedObstalces = (maxRedObstalces > obstacles.Length) ? obstacles.Length : maxRedObstalces;
        maxRedObstalces -= maxGoodObstacles;

        // Shuffle obstacles for minimizing sameish goodobstacle position
        ShuffleList(obstacles);

        foreach (var o in obstacles)
        {
            o.transform.rotation *= Quaternion.Euler(0, Random.Range(0, 360), 0);

            if (currentGreenObstacles < maxGoodObstacles && previousGreenObstacle.name != o.name)
            {
                GoodObstacle(o);
                currentGreenObstacles++;
                previousGreenObstacle = o;
            }
            else if (currentRedObstacles < maxRedObstalces)
            {
                BadObstacle(o);
                currentRedObstacles++;
            }
            else
            {
                NeutralObstacle(o);
            } 
        }
    }

    void BadObstacle(Obstacle o)
    {
        o.material.color = redMaterial.color;
        o.scoreModifier = -50;
        o.timeModifier = -15;
        o.isGoodObstacle = false;
    }

    void GoodObstacle(Obstacle o)
    {
        o.material.color = greenMaterial.color;
        o.scoreModifier = 500;
        o.timeModifier = 15;
        o.isGoodObstacle = true;
    }

    void NeutralObstacle(Obstacle o)
    {
        o.material.color = blackMaterial.color;
        o.scoreModifier = 0;
        o.timeModifier = 0;
        o.isGoodObstacle = false;
    }

    public float CalculatePointDecay()
    {
        return 1 / (timeSinceLastHit + 0.85f);
    }

    public void ShuffleList<T>(T[] list)
    {
        int n = list.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}


