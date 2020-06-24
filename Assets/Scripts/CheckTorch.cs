using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTorch : MonoBehaviour
{
    public bool[] onFire;

    public int torch;

    public Rigidbody rb;


    void Update()
    {
        if (onFire[0] && onFire[1] && onFire[2] && onFire[3])
        {
            rb.AddForce(transform.up * 1, ForceMode.Impulse);
        }
        
    }

    
}
