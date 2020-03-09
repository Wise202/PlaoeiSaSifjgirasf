using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public bool[] litTorches;

    private void Update()
    {
        allTorchesLit();
    }

    void allTorchesLit() 
    {
        if (litTorches[0] && litTorches[1] && litTorches[2] && litTorches[3]) 
        {
            
        }
    }
}
