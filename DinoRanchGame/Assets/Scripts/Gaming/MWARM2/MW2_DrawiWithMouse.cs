using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW2_DrawiWithMouse : MonoBehaviour
{
    Coroutine drawing;

    public void StartLine()
    {
        if(drawing != null)
        {
            StopCoroutine(drawing);

        }

        drawing = StartCoroutine(DrawLine());
        
    }

    public void FinishLine()
    {
        StopCoroutine(drawing);
    }
    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(Resources.Load("Line") as GameObject);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while (true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount-1, position);
            yield return null;
        }
    }
}
