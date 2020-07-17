using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CastingScript1 : MonoBehaviour
{
    public Transform fireBallPoint;
    public GameObject Fire;
    public Transform waterLaunchPoint;
    public GameObject water;

    public FireBall fB;

    [SerializeField]
    private float privateThrust;
    public float thrust
    {
        set 
        {
            if (value < 0f)
            {
                privateThrust = 0f;
            }
            else if (value > 90f)
            {
                privateThrust = 90f;
            }
            else 
            {
                privateThrust = value;
            }
        }
        get { return privateThrust; }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1)) 
        {
            Instantiate(Fire, fireBallPoint.position, fireBallPoint.rotation);
            thrust = 0f;
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            thrust = 0f;
        }
        if (Input.GetMouseButton(0)) 
        {
            
            thrust += Time.deltaTime * 15;
            RaycastVoid();
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            thrust = 0f;
        }
        
    }
    public Color color;
    void RaycastVoid()
    {

        RaycastHit hit;

        Debug.DrawRay(waterLaunchPoint.position, waterLaunchPoint.forward, color, thrust);
        if (Physics.Raycast(waterLaunchPoint.position, waterLaunchPoint.forward, out hit, thrust))
        {
            Debug.Log(" dsa");

            if (hit.collider.tag == "double")
            {
                Debug.Log(" double");
            }

            if (hit.collider.tag == "Flame")
            {

                fB = hit.collider.gameObject.GetComponent<FireBall>();
                fB.hitWithWater = true;
            }
        }

    }
}
