using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] float launchForce = 1200f;
    [SerializeField] float dragRadious = 3.5f;
    Vector2 startinPosition;
    Rigidbody2D rgBody;
    void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
        rgBody.isKinematic = true;
        startinPosition = rgBody.position;
        

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

    }

    private void OnMouseDrag()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
        if (mouseposition.x > startinPosition.x)
            mouseposition.x = startinPosition.x;

        Vector2 direction = mouseposition - startinPosition;
        direction.Normalize();


        float distance = Vector2.Distance(mouseposition, startinPosition);

        if (distance > dragRadious)

            mouseposition = startinPosition + dragRadious * direction;

        transform.position = mouseposition;

    }

    private void OnMouseUp()
    {
        rgBody.isKinematic = false;
        Vector2 currentPosition = rgBody.position;
        Vector2 direction = startinPosition - currentPosition;
        direction.Normalize();
        rgBody.AddForce(direction * launchForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(2f);
    }
}
