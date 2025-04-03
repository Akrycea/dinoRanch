using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public Transform target;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scrollLeft()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
    }

}
