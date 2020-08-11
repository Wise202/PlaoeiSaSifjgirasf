using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Rigidbody rb;
    float f = 10f;
    private void OnCollisionStay(Collision collision)
    {
        
        nothingOn = false;
        Debug.Log(collision.gameObject.name);
        
    }

    private void OnCollisionExit(Collision collision)
    {
        nothingOn = true;
       
    }


    private void OnTriggerStay(Collider other)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        nothingOn = false;
        Debug.Log("lol");
    }

    public bool nothingOn;
    

    private void Update()
    {
        if (nothingOn)
        {
            rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
           
        }
        
    }
}
