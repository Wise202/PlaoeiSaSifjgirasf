using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //this script is going to add force to the object and throw the fireball
    public Rigidbody rb;
    public float thrust = 1.0f;

    private void Start()
    {
        rb.AddForce(transform.forward * thrust);
    }

}
