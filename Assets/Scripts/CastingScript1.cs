using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingScript1 : MonoBehaviour
{
    public Transform fireBallPoint;
    public GameObject Fire;
    public Transform waterLaunchPoint;
    public Rigidbody waterRB;
    public GameObject water;
    public float thrust;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Instantiate(Fire, fireBallPoint.position, fireBallPoint.rotation);
        }
        if (Input.GetMouseButton(0)) 
        {
            thrust += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
           // waterRB.AddRelativeForce(Vector3.forward * thrust);
        
        }
        
    }
}
