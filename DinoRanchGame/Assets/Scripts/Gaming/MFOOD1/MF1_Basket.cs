using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MF1_Bucket : MonoBehaviour
{
    public MF1 mf1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Berry")
        {
            Debug.Log("berry landed in basket");
            mf1.MF1berries_count++;
        }
    }
}
