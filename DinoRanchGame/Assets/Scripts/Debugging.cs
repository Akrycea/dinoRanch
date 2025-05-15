using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    public SpawnManager spawnManager;
    public TimeManager timeManager;

    void Update()
    {
        gibMoney();
        endDay();
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
}
