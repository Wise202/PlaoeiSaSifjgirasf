using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jug : MonoBehaviour
{

    public float waterAmount;
    public bool isFilled;

    public Level1Cont l1C;
    public Rigidbody waterPlane;

    

    private void Start()
    {
    
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
    }

    private void Update()
    {
        if (waterAmount >= 1f) 
        {
            isFilled = true;
        }

        

        if (transform.eulerAngles.x >= 10 || transform.eulerAngles.x <= -10) 
        {
            isFilled = false;
            waterAmount = 0f;
        }
        if (transform.eulerAngles.y >= 10 || transform.eulerAngles.y <= -10)
        {
            isFilled = false;
            waterAmount = 0f;
        }
        if (transform.eulerAngles.z >= 10 || transform.eulerAngles.z <= -10)
        {
            isFilled = false;
            waterAmount = 0f;
        }


    }


}
