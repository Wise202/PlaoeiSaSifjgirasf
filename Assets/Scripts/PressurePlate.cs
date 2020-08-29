using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody sideDoor;
    public AudioSource doorSource;
    public AudioClip up;
    public AudioClip down;
    bool sounds;
    float f = 1f;
    public Animator anim;



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
        if (other.gameObject.name == "Up") 
        {
            doorSource.clip = up;
            doorSource.Play();
        }
        if (other.gameObject.name == "Down") 
        {
            doorSource.clip = down;
            doorSource.Play();
        }
    }
    bool nothingOn;
    private void Update()
    {
        if (nothingOn)
        {
            rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
            sideDoor.AddRelativeForce(transform.up * Time.deltaTime * f * 2, ForceMode.Impulse);

            sideDoor.useGravity = false;

        }
        if (!nothingOn)
        {
            rb.AddRelativeForce(transform.up * Time.deltaTime * f, ForceMode.Impulse);
            sideDoor.useGravity = true;
        }
    }
}
