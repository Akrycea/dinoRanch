using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //lista dinozaur�w do spawnowania
    public GameObject[] spawnableDinos;

    //canvas z wybeiraniem boost�w
    public GameObject[] boostUI;

    public Canvas boostCanvas;

    //szuka prawej kraw�dzi ekranu
    public GameObject edgeTarget;

    public TimeManager timeManager;
    public ClickManager clickManager;

  
    void Start()
    {
        //na starcie wy��czamy ui boost�w
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

    //zmienia pozycje dla nast�pnego kupionego dinozaura
    private void moveSpawnPosition()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3 (74,0,0);
        edgeTarget.transform.position = gameObject.transform.position;
    }

    public void closeBoostUI()
    {
        foreach (var obj in boostUI)
        {
            obj.SetActive(false);
        }
        clickManager.canClickBG = true;

    }

}
