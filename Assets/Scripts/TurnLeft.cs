using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurnLeft : MonoBehaviour
{
    float speed = 100.0f;
    public Level1Cont l1C;
    float speedBack = 1000.0f;
    float backTimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (l1C.spin)
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
            backTimer = 0.2f;
        }
        if (l1C.spinBack) 
        {
            l1C.spin = false;
            transform.Rotate(Vector3.right * speedBack * Time.deltaTime);
            backTimer -= Time.deltaTime;
        }
        
        if (backTimer <= 0) 
        {
            l1C.spinBack = false;
         
        }
    }
}
