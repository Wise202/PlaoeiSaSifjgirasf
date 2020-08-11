using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : MonoBehaviour
{

    float speed = 100f;
    public Transform followPoint;
    public bool grabbed;
    public string pickedUp;
    public Rigidbody rb;

    public PickupRaycast pUR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed) 
        {
            transform.position = followPoint.position;
            gameObject.layer = 14;
            transform.rotation = Quaternion.identity;
        }

        else 
        {
            gameObject.layer = 0;
        }

        if (Input.GetKey(KeyCode.E)) 
        {
            pickedUp = pUR.hitPickUp.transform.gameObject.name;
         
            if (pickedUp == gameObject.name)
            {
                grabbed = true;
                rb.useGravity = false;
                rb.freezeRotation = true;

            }
        }

        if (Input.GetKeyUp(KeyCode.E)) 
        {
            rb.useGravity = true;
            rb.freezeRotation = false;
            grabbed = false;
        }

        
        
    }
}
