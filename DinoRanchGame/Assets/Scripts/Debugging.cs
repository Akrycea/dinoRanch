using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    public SpawnManager spawnManager;
    public TimeManager timeManager;
    public ResourcesManager resourcesManager;

    void Update()
    {
        gibMoney();
        endDay();
        maxRes();
    }

    void gibMoney()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnManager.money = spawnManager.money + 30;
        }
    }

    void endDay()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            timeManager.dayEnds();
        }
    }

    void maxRes()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resourcesManager.WATER = 30;
            resourcesManager.WARM = 30;
            resourcesManager.FOOD = 30;
        }
    }
}
