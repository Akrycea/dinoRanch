using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MW1_counter : MonoBehaviour
{
    public MW1 MiniWARM1;
    public GameObject[] flyingFur;
    private bool leftFurFlown = false;
    private GameObject[] furs;

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        if (MiniWARM1.playingGame)
        {
            MiniWARM1.MW1_count++;
            if (leftFurFlown)
            {
                Instantiate(flyingFur[1]);
                leftFurFlown=false;
            }
            else
            {
                Instantiate(flyingFur[0]);
                leftFurFlown=true;
            }
           
        }
    }

    private void Update()
    {
        if (MiniWARM1.playingGame == false) 
        {
           furs = GameObject.FindGameObjectsWithTag("Fur");
            foreach (var obj in furs)
            {
               Destroy(obj);
            }
        }
    }

}
