using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jug : MonoBehaviour
{

    public float waterAmount;
    public bool isFilled;

    public Animator anim;

    public Level1Cont l1C;

    public AudioSource source;
    

    private void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fluid") 
        {
            source.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fluid")
        {
            waterAmount += Time.deltaTime;
        }

        if (other.gameObject.name == "JugStand")
        {
            l1C.jugInPlace = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "JugStand") 
        {
            l1C.jugInPlace = false;
        }

        if (other.gameObject.tag == "Fluid")
        {
            source.Stop();
        }
    }

    private void Update()
    {
        if (waterAmount >= 1f) 
        {
            isFilled = true;
            anim.SetBool("Filled", true);
        }

        

        if (transform.eulerAngles.x >= 10 || transform.eulerAngles.x <= -10) 
        {
            isFilled = false;
            waterAmount = 0f;
            anim.SetBool("Filled", false);

        }
        if (transform.eulerAngles.y >= 10 || transform.eulerAngles.y <= -10)
        {
            isFilled = false;
            waterAmount = 0f;
            anim.SetBool("Filled", false);

        }

        if (transform.eulerAngles.z >= 10 || transform.eulerAngles.z <= -10)
        {
            isFilled = false;
            waterAmount = 0f;
            anim.SetBool("Filled", false);

        }


    }


}
