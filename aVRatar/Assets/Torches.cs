using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{

    public Room1 room1;

    public bool[] lit;

    public Rigidbody rb;


    private void Update()
    {
        CheckFire();
    }

    void CheckFire()
    {
        if (lit[0])
        {
            room1.litTorches[0] = true;
        }
        if (lit[1])
        {
            room1.litTorches[1] = true;
        }
        if (lit[2])
        {
            room1.litTorches[2] = true;
        }
        if (lit[3])
        {
            room1.litTorches[3] = true;
        }
        if (lit[0] && lit[1] && lit[2] && lit[3])
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }

    }

    


}
