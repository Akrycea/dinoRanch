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
    private bool isLeft;
    private bool isRight;
    private bool isMiddle;

    void Start()
    {
        isMiddle = true;
        isLeft = false; 
        isRight = false;
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
        if (CameraMovL.mouseLover && isMiddle && !isLeft && !isRight)
        {
            scrollToLeft();
        }

        //srcolluj do œrodka jeœli jest po prawej
        else if (CameraMovL.mouseLover && isRight && !isLeft && !isMiddle)
        {
            scrollToMiddle();
        }
    }


    //sprawdza czy gracz leci w prawo
    private void CheckRight()
    {
        //scolluj do prawej jeœli jest poœrodku
        if (CameraMovR.mouseRover && !isLeft && !isRight && isMiddle)
        {
            scrollToRight();
        }

        //scolluj do œrodka jeœli jest po lewej
        else if (CameraMovR.mouseRover && isLeft && !isRight && !isMiddle)
        {
            scrollToMiddle();
        }
    }

    public void scrollToLeft()
    {
        transform.position = Vector3.Lerp(transform.position, targetL.position, 0.004f);
        StartCoroutine(WaitForCameraL());
    }

    public void scrollToMiddle()
    {
        transform.position = Vector3.Lerp(transform.position, targetM.position, 0.004f);
        StartCoroutine(WaitForCameraM());
    }
    public void scrollToRight()
    {
        transform.position = Vector3.Lerp(transform.position, targetR.position, 0.004f);
        StartCoroutine(WaitForCameraR());
    }

    IEnumerator WaitForCameraL()
    {
        yield return new WaitForSeconds(1);
        isLeft = true;
        isRight = false;
        isMiddle = false;
    }

    IEnumerator WaitForCameraR()
    {
        yield return new WaitForSeconds(1);
        isLeft = false;
        isRight = true;
        isMiddle = false;
    }
    IEnumerator WaitForCameraM()
    {
        yield return new WaitForSeconds(1);
        isLeft = false;
        isRight = false;
        isMiddle = true;
    }
}
