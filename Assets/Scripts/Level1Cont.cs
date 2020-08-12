using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Cont : MonoBehaviour
{
    
    public bool spin;
    public bool badBrazier;
    public bool goodBrazier;
    public bool spinBack;
    public float hitFireCount = 1;
    
    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }


    public Rigidbody ExitDoor;
    float doorSpeed = 11f;

    void OpenDoor() 
    {
        //lifts the main door partway then triggers the reset of it if the player hasnt gotten the good brazier under the jug
        if (spin && !goodBrazier ) 
        {
            ExitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
            hitFireCount -= Time.deltaTime;
        }
        //lifts the main door fully if the player has the good brazier in place
        if (spin && goodBrazier)
        {
            ExitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        //stops adding force to the main door dropping it back down to its starting position
        //if badBrazier is true the door lifts partway further but still not fully
        if (hitFireCount <= 0) 
        {
            spinBack = true;
            if (!badBrazier)
            {
                hitFireCount = 1f;
            }
            if(badBrazier) 
            {
                hitFireCount = 1.1f;
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
            hitFireCount = 1.1f;
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
