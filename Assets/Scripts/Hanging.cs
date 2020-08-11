using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging : MonoBehaviour
{

    public bool hanging = true;
    public FixedJoint fJ;

    void Update()
    {
        if (!hanging) 
        {
            fJ.connectedBody = null;   
        }
    }
}
