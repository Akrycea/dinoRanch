using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //lista dinozaurów do spawnowania
    public GameObject[] spawnableDinos;

    //canvas z wybeiraniem boostów
    public GameObject[] boostUI;

    public Canvas boostCanvas;

    //szuka prawej krawêdzi ekranu
    public GameObject edgeTarget;

    public TimeManager timeManager;
    public ClickManager clickManager;
    public ResourcesManager resourcesManager;

  
    void Start()
    {
        //na starcie wy³¹czamy ui boostów
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }


    }

  
    void Update()
    {
        
    }

    public void openBoostWindow()
    {
        foreach (var obj in boostUI)
        {
            obj.SetActive(true);
        }
    }

    //spawnuje kupionego dinozaura 1
    public void spawn1BoughtDino()
    {
        moveSpawnPosition();
        Instantiate(spawnableDinos[0], gameObject.transform.position, Quaternion.identity );
        closeBoostUI();
    }

    //zmienia pozycje dla nastêpnego kupionego dinozaura
    private void moveSpawnPosition()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3 (74,0,0);
        edgeTarget.transform.position = gameObject.transform.position;
    }

    //zamykanie UI i odpalanie nastêpnego dnia
    public void closeBoostUI()
    {
        //zamyka boost ui
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }
        clickManager.canClickBG = true;

        //odpala nastêpny dzieñ
        timeManager.resetTime();
        timeManager.didGameStart = true;

        //odnawia resources
        resourcesManager.resetResources();

    }

}
