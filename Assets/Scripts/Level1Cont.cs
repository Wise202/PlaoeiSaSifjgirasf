using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Cont : MonoBehaviour
{
    
    public bool spin;
    public bool badBrazier;
    public bool goodBrazier;
    public bool spinBack;
    float hitFireCount = 2.5f;
    
    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }


    public Rigidbody exitDoor;
    float doorSpeed = 10f;

    void OpenDoor() 
    {
        //lifts the main door partway then triggers the reset of it if the player hasnt gotten the good brazier under the jug
        if (spin && !goodBrazier ) 
        {
            exitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
            hitFireCount -= Time.deltaTime;
            exitDoor.useGravity = true;
        }
        //lifts the main door fully if the player has the good brazier in place
        if (spin && goodBrazier)
        {
            exitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
            exitDoor.useGravity = true;
        }
        //stops adding force to the main door dropping it back down to its starting position
        //if badBrazier is true the door lifts partway further but still not fully
        if (hitFireCount <= 0) 
        {
            spinBack = true;
            exitDoor.useGravity = true;
            if (!badBrazier)
            {
                hitFireCount = 2f;
            }
            if(badBrazier) 
            {
                hitFireCount = 2.5f;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)")
        {
            spin = true;
            
        }
        if (other.gameObject.name == "BadBrazier") 
        {
            hitFireCount = 2.5f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "GoodBrazier")
        {
            goodBrazier = true;
        }
        if (other.gameObject.name == "BadBrazier")
        {
            badBrazier = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BadBrazier") 
        {
            badBrazier = false;
        }
        if (other.gameObject.name == "GoodBrazier") 
        {
            goodBrazier = false;
        }

    }



}
