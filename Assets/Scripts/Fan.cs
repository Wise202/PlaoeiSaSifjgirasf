using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool Powered;
    public bool waterTouching;
    public bool electricityOn;



    void Update()
    {
        if (waterTouching && electricityOn) { Powered = true; }
    }
}
