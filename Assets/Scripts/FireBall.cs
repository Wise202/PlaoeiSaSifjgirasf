using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //this script is going to add force to the object and throw the fireball
    public Rigidbody rb;
    public float thrust = 10000f;

    public float timer = 5f;

    private void Start()
    {
        rb.AddRelativeForce(-Vector3.forward * thrust);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
