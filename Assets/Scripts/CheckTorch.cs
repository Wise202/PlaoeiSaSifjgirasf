using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorch : MonoBehaviour
{
    public bool[] onFire;

    public int torch;


    void Update()
    {
        if (onFire[0] && onFire[1] && onFire[2] && onFire[3])
        {
            print("11");
        }

        else { }
    }

    
}
