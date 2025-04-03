using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public CameraMovementLeft CameraMovL;
    public CameraMovementRight CameraMovR;
    public Transform targetL;
    public Transform targetM;
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
        //scrolluj do lewej jeœli jest poœrodku
        if (CameraMovL.mouseLover)
        {
            scrollToLeft();
        }

    }


    //sprawdza czy gracz leci w prawo
    private void CheckRight()
    {
        //scolluj do prawej jeœli jest poœrodku
        if (CameraMovR.mouseRover)
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
