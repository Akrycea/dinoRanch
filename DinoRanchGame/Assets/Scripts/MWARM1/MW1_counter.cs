using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW1_counter : MonoBehaviour
{
    public MW1 MiniWARM1;

    void OnMouseOver()
    {

    }

    void OnMouseExit()
    {
        if (MiniWARM1.playingGame)
        {
            MiniWARM1.MW1_count++;
        }
    }

}
