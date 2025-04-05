using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ClickManager : MonoBehaviour
{
    public bool canClickBG;
    public MW1 MWarm1;
    void Start()
    {
        canClickBG = true;
    }

    void Update()
    {
        whatGetsClicked();
    }

    
    //wyczuwa co zosta³o klikniête i mówi co zrobiæ w zwi¹zku z tym
    void whatGetsClicked()
    {

        if (Input.GetMouseButtonDown(0) && canClickBG)
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            //sprawdza wszystkie dinozaury z tagiem CIEP£A
            if (rayHit.transform.CompareTag("WARM"))
            {
                //co robi klikniêcie na danego dinozaura
                if (rayHit.transform.name == "Dino1")
                {
                    Debug.Log("dino1");
                    MWarm1.StartMWarm1();
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
