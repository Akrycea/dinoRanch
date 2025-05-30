using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class MW1 : MonoBehaviour
{
    //zasoby
    public ResourcesManager RManager;

    //rzeczy do minigierki
    public ClickManager clickManager;
    public SpawnManager spawnManager;
    public int MW1_count;
    public GameObject[] MinigameObjects;
    public TMP_Text MW1gameText;


    public bool playingGame = false;

    [SerializeField] private float gameTimer;
    private bool timeStart;
  
    void Start()
    {
        
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        timeStart = false;
    }

    
    void Update()
    {
        if (timeStart)
        {
            clickManager.canClickBG = false;
            MW1StartTimer();
            MWarm1Playing();
            if (MW1_count >= 1)
            {
                MW1gameText.text = MW1_count + " fur gathered";
            }
        }
        
    }

    //odpalenie gry
    public void StartMWarm1()
    {
        //odpala si� okienko gry
        foreach (var obj in MinigameObjects) 
        {
            obj.SetActive(true);
        }

        MW1gameText.text = "Swipe to gather fur!";
        playingGame = true;
        MW1_count = 0;
        gameTimer = 0;
        timeStart = true;
       
    }

    //odpalamy czas
    private void MW1StartTimer()
    {    
        gameTimer = gameTimer + Time.deltaTime;
    }

    //co dzieje si� podczas gry
    void MWarm1Playing()
    {
        //tu zrobic animacje futra latajacego na lewo i prawo bo jest odcinane lol
        

        //koncz gre po danym czasie
        if (gameTimer > 5)
        {
            MWarm1End();
        }
    }


    //zako�czenie gry
    void MWarm1End()
    {

        playingGame = false;

        //czeka chwilke z zamkni�ciem gry aby pokazac ile zdobyto zasob�w
        StartCoroutine(waitingToEndGame());
        
        timeStart = false;

        //dodaje zdobyte zasoby
        RManager.WARM = RManager.WARM + MW1_count;

        //dodaje zdobytą kasę za opiekę
        spawnManager.money =  spawnManager.money + MW1_count/2;
        

        //przywraca klikanie na tło
        clickManager.canClickBG = true;
    }

    IEnumerator waitingToEndGame()
    {
        yield return new WaitForSeconds(1);
        //zamyka okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }

    }
}
