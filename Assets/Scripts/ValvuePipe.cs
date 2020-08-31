using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvuePipe : MonoBehaviour
{

    float speed = 50.0f;
    public PickupRaycast pUR;
    string hit;
    bool turning;
    bool turnt = true;
    float spinTime = 1f;
    public bool water;
    



    void Update()
    {
        TurnPipe();
    }

    void TurnPipe()
    {
        

        if (Input.GetKeyUp(KeyCode.E)) 
        {
            hit = null;
        }

    

        if (turning && !turnt)
        {
            spinTime -= Time.deltaTime;
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
            pUR.gameObject.tag = "Water";
            water = true;
            
        }
        if (!turning && !turnt)
        {
            pUR.gameObject.tag = "NoWater";
            spinTime -= Time.deltaTime;
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
            water = false;
        }

        if (spinTime <= 0)
        {
            turnt = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           

            if (other.gameObject.tag == "NoWater")
            {
                
                turning = true;
                turnt = false;
                spinTime = 1f;
            }
            if (other.gameObject.tag == "Water")
            {
                turnt = false;
                spinTime = 1f;
                turning = false;
            }

        }
    }
}
