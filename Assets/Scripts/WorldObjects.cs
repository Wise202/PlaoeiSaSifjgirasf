using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjects : MonoBehaviour
{
    public Rigidbody rb;

    public bool isBeingHeld;

    void FixedUpdate()
    {
        if (isBeingHeld == false)
        {
            rb.AddForce(Physics.gravity * rb.mass);
        }
        else { }
    }

}
