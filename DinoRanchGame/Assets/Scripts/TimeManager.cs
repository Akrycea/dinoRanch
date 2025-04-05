using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public ResourcesManager RManager;
    public float currentTime;
    void Start()
    {
        currentTime = 100;
    }

    
    void Update()
    {
        //dodaæ ¿e time passing po rozpoczêciu rozgrywki dopiero
        timePassing();
    }

    //metoda mijania czasu
    void timePassing()
    {
        currentTime = currentTime - Time.deltaTime;

        //spadanie iloœci zasobów z czasem
        RManager.WATER = RManager.WATER - (Time.deltaTime / 2);
        RManager.FOOD = RManager.FOOD - (Time.deltaTime/2);
        RManager.WARM = RManager.WARM - (Time.deltaTime / 2);

        //koniec dnia po skoñczeniu siê czasu
        if ( currentTime <= 0)
        {
            dayEnds();
        }
    }

    //koniec dnia
    void dayEnds()
    {
        Debug.Log("day ended");
    }
}
