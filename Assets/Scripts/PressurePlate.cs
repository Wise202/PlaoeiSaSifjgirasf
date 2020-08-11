using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Rigidbody rb;
    float f = 1f;
    private void OnCollisionStay(Collision collision)
    {
        rb.useGravity = true;
        Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        nothingOn = true;
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
    }
    bool nothingOn;
    private void Update()
    {
        if (nothingOn) 
        {
            rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
        }
    }
}
