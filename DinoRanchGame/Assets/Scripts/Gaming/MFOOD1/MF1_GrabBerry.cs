using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MF1_GrabBerry : MonoBehaviour
{
    private bool grabbed = false;

    private Camera mainCamera;

    
    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        //je�li obiekt jest klikni�ty to ci�gnie go za myszk�
        if (grabbed)
        {
            Vector2 mousepos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousepos;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Basket")
        {
            Debug.Log("berry dropped in basket!");
            Destroy(gameObject);
        }
    }

    //sprawdza czy klikni�ty i wy��cza fizyke je�li tak
    private void OnMouseDown()
    {
        grabbed = true;
        GetComponent<Rigidbody2D>().isKinematic = true;

    }

    private void OnMouseUp()
    {
        grabbed = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
