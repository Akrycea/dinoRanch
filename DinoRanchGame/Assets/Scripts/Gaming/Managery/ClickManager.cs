using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ClickManager : MonoBehaviour
{
    public bool canClickBG;

    //odwołania do gierek

    //ciepła
    public MW1 MWarm1;
    public MW2 MWarm2;

    //jedzenia
    public MF1 MFood1;

    //wody
    public MWT1pipemanager MWater1;
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

        if (Input.GetMouseButtonDown(0))
        {
            if (canClickBG)
            {
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

                //sprawdza wszystkie dinozaury z tagiem CIEP�A
                if (rayHit.transform.CompareTag("WARM"))
                {
                    //co robi klikniecie na danego dinozaura
                    if (rayHit.transform.name == "DefDino1")
                    {
                        Debug.Log("Defdino1");
                        MWarm1.StartMWarm1();
                    }
                    else if (rayHit.transform.name == "Dino1(Clone)")
                    {
                        Debug.Log("dino1");
                        MWarm2.StartMWarm2();
                    }

                }

                //sprawdza wszystkie dinozaury z tagiem WODY
                else if (rayHit.transform.CompareTag("WATER"))
                {
                    if (rayHit.transform.name == "DefDino2")
                    {
                        Debug.Log("Defdino2");
                        MWater1.StartMWater1();
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
            else
            {
                Debug.Log("can't click BG right now!");
            }


        }
    }


}
