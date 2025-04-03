using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ClickManager : MonoBehaviour
{
    void Start()
    {

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
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            //sprawdza wszystkie dinozaury z tagiem CIEP�A
            if (rayHit.transform.CompareTag("WARM"))
            {
                //co robi klikni�cie na danego dinozaura
                if (rayHit.transform.name == "Dino1")
                {
                    Debug.Log("dino1");
                }
                
            }

            //sprawdza wszystkie dinozaury z tagiem WODY
            else if (rayHit.transform.CompareTag("WATER"))
            {
                if (rayHit.transform.name == "Dino2")
                {
                    Debug.Log("dino2");
                }
            }

            //sprawdza wszystkie dinozaury z tagiem JEDZENIA
            else if (rayHit.transform.CompareTag("FOOD"))
            {
                if (rayHit.transform.name == "Dino3")
                {
                    Debug.Log("dino3");
                }

            }


        }
    }


}
