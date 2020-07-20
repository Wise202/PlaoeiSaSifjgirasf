using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CastingScript1 : MonoBehaviour
{
    public Transform fireBallPoint;
    public GameObject Fire;
    public GameObject waterLaunchPoint;
    public GameObject water;
    public GameObject S;
    public float speed;
    public GameObject E;

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
    public Vector3 waterArcRotation;
    private void Start()
    {
       // waterArcRotation = new Vector3(waterLaunchPoint.transform.eulerAngles.x, waterLaunchPoint.transform.eulerAngles.y, waterLaunchPoint.transform.eulerAngles.z);
    }


    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs() 
    {
        if (Input.GetMouseButtonUp(1))
        {
            Instantiate(Fire, fireBallPoint.position, fireBallPoint.rotation);
            thrust = 0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            waterArcRotation = new Vector3(S.transform.eulerAngles.x, S.transform.eulerAngles.y, S.transform.eulerAngles.z);
            thrust = 0f;
            waterLaunchPoint.transform.eulerAngles = waterArcRotation;
        }
        if (Input.GetMouseButton(0))
        {
            thrust += Time.deltaTime * 15;

           

            Vector3 direction = E.transform.position - waterLaunchPoint.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            waterLaunchPoint.transform.rotation = Quaternion.Lerp(waterLaunchPoint.transform.rotation, rotation, speed * Time.deltaTime);

            RaycastVoid();

        }
        if (Input.GetMouseButtonUp(0))
        {
            waterLaunchPoint.transform.eulerAngles = waterArcRotation;
            thrust = 0f;
        }
    }

    public Color color;
    void RaycastVoid()
    {

        RaycastHit hit;

        Debug.DrawRay(waterLaunchPoint.transform.position, waterLaunchPoint.transform.forward, color, thrust);
        if (Physics.Raycast(waterLaunchPoint.transform.position, waterLaunchPoint.transform.forward, out hit, thrust))
        {
            if (hit.collider.tag == "Untagged")
            {
                Debug.Log(" Noor");
            }
            if (hit.collider.tag == "Floor")
            {
                Debug.Log(" Floor");
            }

            if (hit.collider.tag == "Flame")
            {

                fB = hit.collider.gameObject.GetComponent<FireBall>();
                fB.hitWithWater = true;
            }
        }

    }
}
