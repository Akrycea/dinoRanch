using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    private int selectedDino;
   

    void Start()
    {
       selectedDino = 0;
    }

    void Update()
    {
        
    }

    public void buyDino1()
    {
        Debug.Log("bought new dino");
    }

    void spawnDino()
    {
        if (selectedDino == 1) 
        {

        }
    }
}
