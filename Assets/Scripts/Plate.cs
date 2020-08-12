using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sideDoor;
    float f = 1f;
    float weight = 20f;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "PlateUp")
        {

            nothingOn = true;

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
        }
    }

    public bool nothingOn;
    

    private void Update()
    {

        rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);

        //if (!nothingOn) 
        //{

        //    sideDoor.AddRelativeForce(-transform.up * Time.deltaTime * weight, ForceMode.Impulse);
        //}
        if (nothingOn) 
        {

            sideDoor.AddRelativeForce(transform.up * Time.deltaTime * weight, ForceMode.Impulse);
        }
    }
}
