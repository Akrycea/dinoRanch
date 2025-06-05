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
        //jeœli obiekt jest klikniêty to ci¹gnie go za myszk¹
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

    //sprawdza czy klikniêty i wy³¹cza fizyke jeœli tak
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
