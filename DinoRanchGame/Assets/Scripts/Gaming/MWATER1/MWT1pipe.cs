using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWT1pipe : MonoBehaviour
{
    float[] rotations ={ 0,90,180,270 };

    public float correctRotation;
    [SerializeField]
    bool isPlaced = false;

    private void Start()
    {
        correctRotation = transform.localEulerAngles.z;
        int rand = Random.Range(0, rotations.Length);   
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        Check();

    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        Check();
    }

    void Check()
    {
        if (transform.eulerAngles.z == correctRotation && isPlaced == false)
        {
            isPlaced = true;
        }
        else if (isPlaced == true)
        {
            isPlaced = false;
        }
    }

}
