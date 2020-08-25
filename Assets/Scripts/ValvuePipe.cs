using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvuePipe : MonoBehaviour
{

    float speed = 50.0f;
    float speedBack = 300.0f;
    public PickupRaycast pUR;
    string hit;
    bool turning;
    bool turnt;
    float spinBack = 1f;

    void Update()
    {
        hit = pUR.hitPickUp.transform.gameObject.name;

        if (hit == gameObject.name && !turning)
        {
            turning = true;
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if (hit == gameObject.name && turning)
        {
            transform.Rotate(Vector3.left * speed);
            
            spinBack -= Time.deltaTime;

        }

        if (spinBack <= 0) 
        {
            turnt = true;
        }

        if (turnt == true) 
        {
            
        }

    }


}
