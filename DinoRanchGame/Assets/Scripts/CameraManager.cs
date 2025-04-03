using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{

   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scrollLeft()
    {
        transform.position += new Vector3 (-2,0,0);
    }

}
