using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public bool[] litTorches;
    bool mouseButtonDown;
    public GameObject fB;
    public Transform p;

    private void Update()
    {
        allTorchesLit();
        SpawnFireBall();
    }

    void allTorchesLit() 
    {
        if (litTorches[0] && litTorches[1] && litTorches[2] && litTorches[3]) 
        {
            
        }
    }

    void SpawnFireBall() 
    {
        if (Input.GetMouseButtonDown(0) && mouseButtonDown == false) 
        {
            mouseButtonDown = true;
            Instantiate(fB, p.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            mouseButtonDown = false;
        }
    }



}
