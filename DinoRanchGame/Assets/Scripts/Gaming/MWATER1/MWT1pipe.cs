using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWT1pipe : MonoBehaviour
{
    //possible rotation of the pipes
    float[] rotations ={ 0,90,180,270 };

    //everything related to rotations
    public float[] correctRotation;
    //this checks if the pipe is placed in its original rotation
    public bool isPlaced = false;
    //this needs to be here for setting original rotations
    int PossibleRots = 1;

    public MWT1pipemanager manager;
    

    private void Start()
    {
        manager = GameObject.Find("pipesmanager").GetComponent<MWT1pipemanager>();

        //this takes the lenght of the array (IN INSPECTOR!!!, i set it as 1 in code, but if the pipe has 2+ you have to set it manually)
        PossibleRots = correctRotation.Length;
        //this sets 1st correct rotation as the one that specific pipe starts with (if pipe has 2+ you have to set them in inspector)
        correctRotation[0] = transform.localEulerAngles.z;
        
        int rand = Random.Range(0, rotations.Length);  
        //this transforms all the pipes into random rotations, from the 
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        Check();

    }

    private void OnMouseDown()
    {
        //when u click the pipe moves
        transform.Rotate(new Vector3(0, 0, -90));

        Check();
    }

    //this checks if the current rotation of the pipe is the same as its original one, 1st if for the is for pipes with multiple possible rotations
    void Check()
    {
        if (PossibleRots > 1)
        {
            if (Mathf.Floor(transform.eulerAngles.z) == correctRotation[0]|| Mathf.Floor(transform.eulerAngles.z) == correctRotation[1] && isPlaced == false)
            {
                isPlaced = true;
                manager.solution += 1;
            }
            else if (isPlaced == true)
            {
                Debug.Log("false");
                isPlaced = false;
                manager.solution -= 1;
            }
        }
        else
        {
            if (Mathf.Floor(transform.eulerAngles.z) == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                manager.solution += 1;
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                manager.solution -= 1;
            }
        }
    }
}
