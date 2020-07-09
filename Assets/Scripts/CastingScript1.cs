using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingScript1 : MonoBehaviour
{
    public Transform fireBallPoint;
    public GameObject Fire;
    public Transform waterLaunchPoint;
    public GameObject water;
    public float thrust;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1)) 
        {
            Instantiate(Fire, fireBallPoint.position, fireBallPoint.rotation);
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            thrust = 0f;
        }
        if (Input.GetMouseButton(0)) 
        {
            thrust += Time.deltaTime * 150;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            Instantiate(water, waterLaunchPoint.position, waterLaunchPoint.rotation);
        }
        
    }
}
