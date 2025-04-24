using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostPages : MonoBehaviour
{
    public GameObject[] buttons;
    public int pagesLeft;
    public int pagesRight;

    //sprawdza w któr¹ strone przewin¹æ i czy mo¿e przewinaæ dalej
    public void NextPage()
    {
        if (pagesLeft < 1) 
        {
            foreach (var button in buttons)
            {
                button.transform.position = button.transform.position + new Vector3(-1800, 0, 0);
            }
            pagesLeft ++;
            pagesRight --;

        }

    }

    public void PreviousPage() 
    {
        if ( pagesRight < 1)
        {
            foreach (var button in buttons)
            {
                button.transform.position = button.transform.position + new Vector3(1800, 0, 0);
            }
            pagesRight++;
            pagesLeft--;

        }
    }


    
}
