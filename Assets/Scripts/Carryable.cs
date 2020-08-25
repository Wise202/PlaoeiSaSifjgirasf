using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : MonoBehaviour
{

    float speed = 100f;
    public Transform followPoint;
    public bool grabbed;
    public bool beenGrabbed;
    public string pickedUp;
    public Rigidbody rb;

    public CastingScript1 cS1;
    public string hit;
    public PickupRaycast pUR;
    public Transform player;
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
            gameObject.layer = 15;
        }

        if (Input.GetKeyDown(KeyCode.E)) 
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


        if (Input.GetMouseButton(0) && !grabbed) 
        {
            hit = cS1.hit.transform.gameObject.name;
            if (hit == gameObject.name) 
            {
                rb.AddRelativeForce(player.forward * 10f, ForceMode.Impulse);
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            hit = null;
        }
        
        
        
    }

   
}
