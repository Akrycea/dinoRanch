using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public ClickManager ClickManager;
    public CameraMovementLeft CameraMovL;
    public CameraMovementRight CameraMovR;
    public Transform targetL;
    public Transform targetR;



    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        CheckLeft();
        CheckRight();
    }

    //sprawdza czy gracz leci w lewo
    private void CheckLeft()
    {
        //scrolluj do lewej
        if (CameraMovL.mouseLover && ClickManager.canClickBG)
        {
            scrollToLeft();
        }

    }


    //sprawdza czy gracz leci w prawo
    private void CheckRight()
    {
        //scolluj do prawej
        if (CameraMovR.mouseRover && ClickManager.canClickBG)
        {
            scrollToRight();
        }

    }

    public void scrollToLeft()
    {
        transform.position = Vector3.Lerp(transform.position, targetL.position, 0.004f);
        StartCoroutine(WaitForCameraL());
    }

    public void scrollToRight()
    {
        transform.position = Vector3.Lerp(transform.position, targetR.position, 0.004f);
        StartCoroutine(WaitForCameraR());
    }

    IEnumerator WaitForCameraL()
    {
        yield return new WaitForSeconds(1);
   
    }

    IEnumerator WaitForCameraR()
    {
        yield return new WaitForSeconds(1);
    
    }

}
