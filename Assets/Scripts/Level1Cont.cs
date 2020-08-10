using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Cont : MonoBehaviour
{

    public bool spin;
    public bool badBrazier;
    public bool goodBrazier;
    public bool spinBack;
    float hitFireCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }


    public Rigidbody ExitDoor;
    float doorSpeed = 11f;
    void OpenDoor() 
    {
        if (spin && !goodBrazier ) 
        {
            ExitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
            hitFireCount -= Time.deltaTime;
        }

        if (spin && goodBrazier)
        {
            ExitDoor.AddRelativeForce(transform.up * doorSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (hitFireCount <= 0 && badBrazier) 
        {
            spinBack = true;
            hitFireCount = 0.01f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)")
        {
            spin = true;
            hitFireCount = 1;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "")
        {
            goodBrazier = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)") 
        {
            spin = false;
        }
    }



}
