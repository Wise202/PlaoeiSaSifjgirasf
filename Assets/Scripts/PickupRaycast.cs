using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupRaycast : MonoBehaviour
{
    public bool hitPipe;
    public RaycastHit hitPickUp;

    private void Update()
    {
        pickUpCheck();
    }

    Color color = Color.blue;
    float size = 3f;
    void pickUpCheck() 
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            Debug.DrawRay(transform.position, transform.forward, color);
            if (Physics.Raycast(transform.position, transform.forward, out hitPickUp, size)) 
            {

            }
        }

    }


}
