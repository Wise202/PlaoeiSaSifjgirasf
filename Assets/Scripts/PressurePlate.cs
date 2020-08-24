using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sideDoor;
    float f = 1f;



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Up")
        {
            nothingOn = true;
        }
        if (other.gameObject.name == "Down")
        {
            nothingOn = false;
        }

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
            sideDoor.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);

            sideDoor.useGravity = false;

        }
        if (!nothingOn)
        {
            rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
            sideDoor.useGravity = true;
        }
    }
}
