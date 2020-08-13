using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sideDoor;
    float f = 1f;
    float weight = 20f;
    public SideDoor sD;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "PlateUp")
        {

            nothingOn = true;
            sD.l = true;

        }


        Debug.Log(collision.gameObject.name);
        
    }

    private void OnCollisionExit(Collision collision)
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PlateDown") 
        {
            nothingOn = false;
            sD.l = true;
        }
    }

    public bool nothingOn;
    

    private void Update()
    {
        rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
    }
}
