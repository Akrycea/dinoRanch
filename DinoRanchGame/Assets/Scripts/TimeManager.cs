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
        //doda� �e time passing po rozpocz�ciu rozgrywki dopiero
        timePassing();
    }

    //metoda mijania czasu
    void timePassing()
    {
        currentTime = currentTime - Time.deltaTime;

        //spadanie ilo�ci zasob�w z czasem
        RManager.WATER = RManager.WATER - (Time.deltaTime / 2);
        RManager.FOOD = RManager.FOOD - (Time.deltaTime/2);
        RManager.WARM = RManager.WARM - (Time.deltaTime / 2);

        //koniec dnia po sko�czeniu si� czasu
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
