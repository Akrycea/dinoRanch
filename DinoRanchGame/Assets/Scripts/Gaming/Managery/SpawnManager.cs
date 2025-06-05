using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IDataManager
{
    //lista dinozaurów do spawnowania
    public GameObject[] spawnableDinos;

    //canvas z wybeiraniem boostów
    public GameObject[] boostUI;


    //szuka prawej krawêdzi ekranu
    public GameObject edgeTarget;

    //ustala kase
    public int money;
    public TMP_Text moneyCount;

    //potrzebne managery
    public TimeManager timeManager;
    public ClickManager clickManager;
    public ResourcesManager resourcesManager;

    //zak³adki z dinozaurami i ich przewijanie
    public BoostPages boostPages;

    //na chama boole który dino kupiony a który nie
    public bool dino1bought;


    void Start()
    {
        //na starcie wy³¹czamy ui boostów
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }

        //zeruje kase na pocz¹tku lvl
        //money = 0;
        moneyCount.text = money.ToString("0");

        if (dino1bought)
        {
            Instantiate(spawnableDinos[0], gameObject.transform.position + new Vector3(30, 0, 0), Quaternion.identity);
        }


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
        //zeruje przewijanie dinozaurów
        boostPages.pagesLeft = 0;
        boostPages.pagesRight = 1;
    }

    //spawnuje kupionego dinozaura 1
    public void spawn1BoughtDino()
    {
        moveSpawnPosition();
        Instantiate(spawnableDinos[0], gameObject.transform.position, Quaternion.identity);
        dino1bought = true;
        money = money - 10;
        closeBoostUI();
        
    }

    //zmienia pozycje dla nastêpnego kupionego dinozaura
    private void moveSpawnPosition()
    {
        Debug.Log(gameObject.transform.position);
        gameObject.transform.position = gameObject.transform.position + new Vector3 (30,0,0);
        edgeTarget.transform.position = gameObject.transform.position + new Vector3(0,0,-7);
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

    //DO £ADOWANIA I ZAPISYWANIA GRY
    public void LoadData(DinoData data)
    {
        this.money = data.MONEY;
        this.edgeTarget.transform.position = data.rightCameraTarget;

        this.dino1bought = data.dino1bought;
    }

    public void SaveData(ref DinoData data)
    {
        data.MONEY = this.money;
        data.rightCameraTarget = this.edgeTarget.transform.position;

        data.dino1bought = this.dino1bought;
    }

}
