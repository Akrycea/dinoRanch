using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class MF1 : MonoBehaviour
{
     //zasoby
    public ResourcesManager RManager;

    //rzeczy do minigierki
    public ClickManager ClickManager;
    public GameObject[] MinigameObjects;
    public int MF1berries_count;

    [SerializeField] private float gameTimer;
    private bool timeStart;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }
        timeStart = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {
            ClickManager.canClickBG = false;
            MF1StartTimer();
            MFood1Playing();
            //if (MW1_count >= 1)
            //{
            //    MW1gameText.text = MW1_count + " berries";
           // }
        }
    
    }
    void MF1StartTimer()
    {
        gameTimer = gameTimer - Time.deltaTime;
        
    }

    public void StartMF1()
    {
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(true);
        }
        MF1berries_count=0;
        gameTimer=10;
        timeStart=true;
    }
    void MFood1Playing()
    {
        if (gameTimer < 0)
        {
            Debug.Log("end game");
            MFood1End();

        }
    }
    void MFood1End()
    {
        timeStart=false;
        RManager.FOOD= RManager.FOOD + MF1berries_count;
        StartCoroutine(waitingToEndGame());
        ClickManager.canClickBG=true;
        
    }
    IEnumerator waitingToEndGame()
    {
        yield return new WaitForSeconds(3);
        //zamyka okienko gry
        foreach (var obj in MinigameObjects)
        {
            obj.SetActive(false);
        }

    }
}
