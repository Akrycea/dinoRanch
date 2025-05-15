using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MW2_FollowMouse : MonoBehaviour
{
    //do sprawdzania czy sie dotykaja
    public Collider2D shapeCollider1;
    public Collider2D cursorCollider;

    //manager gry
    public MW2 mw2;
   
    private Camera mainCamera;

    //pr�dko�� kursora
    [SerializeField] private float maxSpeed = 10f;
    
    void Start()
    {
        mainCamera = Camera.main;
        
    }

    
    void Update()
    {
        FollowMousePositionDelay(maxSpeed);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("touching");
        mw2.MW2_count++;
    }



    //ka�e obiektowi i�� za myszk�
    //private void FollowMousePosition()
    //{
    //    transform.position = GetWorldPositionFromMouse();
    //}

    //obiekt idzie za myszk� z op�nieniem
    private void FollowMousePositionDelay(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }

    //m�wi nam gdzie na ekranie jest myszka
    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
