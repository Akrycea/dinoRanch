using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ClickManager : MonoBehaviour
{
    public bool canClickBG;
    public MW1 MWarm1;
    public MF1 MFood1;
    void Start()
    {
        canClickBG = false;
    }

    void Update()
    {
        whatGetsClicked();
    }

    
    //wyczuwa co zosta�o klikni�te i m�wi co zrobi� w zwi�zku z tym
    void whatGetsClicked()
    {

        if (Input.GetMouseButtonDown(0) && canClickBG)
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            //sprawdza wszystkie dinozaury z tagiem CIEP�A
            if (rayHit.transform.CompareTag("WARM"))
            {
                //co robi klikni�cie na danego dinozaura
                if (rayHit.transform.name == "DefDino1")
                {
                    Debug.Log("Defdino1");
                    MWarm1.StartMWarm1();
                }
                
            }

            //sprawdza wszystkie dinozaury z tagiem WODY
            else if (rayHit.transform.CompareTag("WATER"))
            {
                if (rayHit.transform.name == "DefDino2")
                {
                    Debug.Log("Defdino2");
                }
            }

            //sprawdza wszystkie dinozaury z tagiem JEDZENIA
            else if (rayHit.transform.CompareTag("FOOD"))
            {
                if (rayHit.transform.name == "DefDino3")
                {
                    Debug.Log("Defdino3");
                    MFood1.StartMF1();
                }

            }


        }
    }


}
