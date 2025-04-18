using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //lista dinozaur�w do spawnowania
    public GameObject[] spawnableDinos;

    //canvas z wybeiraniem boost�w
    public GameObject[] boostUI;


    //szuka prawej kraw�dzi ekranu
    public GameObject edgeTarget;

    //ustala kase
    public int money;
    public TMP_Text moneyCount;

    //potrzebne managery
    public TimeManager timeManager;
    public ClickManager clickManager;
    public ResourcesManager resourcesManager;

  
    void Start()
    {
        //na starcie wy��czamy ui boost�w
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }

        //zeruje kase na pocz�tku lvl
        money = 0;
        moneyCount.text = money.ToString("0");

    }

  
    void Update()
    {
        moneyCount.text = money.ToString("0");
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
        money = money - 10;
        closeBoostUI();
    }

    //zmienia pozycje dla nast�pnego kupionego dinozaura
    private void moveSpawnPosition()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3 (30,0,0);
        edgeTarget.transform.position = gameObject.transform.position;
    }

    //zamykanie UI i odpalanie nast�pnego dnia
    public void closeBoostUI()
    {
        //zamyka boost ui
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }
        clickManager.canClickBG = true;

        //odpala nast�pny dzie�
        timeManager.resetTime();
        timeManager.didGameStart = true;

        //odnawia resources
        resourcesManager.resetResources();

    }

}
