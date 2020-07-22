using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CastingScript1 : MonoBehaviour
{
    //fireballpoint is the spawning point for the fireball prefab
    public Transform fireBallPoint;
    //fire gameobject is the Fire prefab
    public GameObject Fire;
    //waterLaunchPoint is the gameobject with the line renderer on it
    public GameObject waterLaunchPoint;
    //waterParticles are the water Particles
    public GameObject[] waterParticles;
    //S is the starting spot for the raycast to point at
    public GameObject startRay;
    //speed is the speed at which the raycast object turns
    public float speed;
    //E is the ending point that the raycast will turn towards
    public GameObject endRay;
    //fB is used to set the fireball into its "off conditionals"
    public FireBall fB;

    public CheckTorch cT;

    public Torch torch;

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

            waterParticles[0].SetActive(true);
            waterParticles[1].SetActive(true);
            waterArcRotation = new Vector3(startRay.transform.eulerAngles.x, startRay.transform.eulerAngles.y, startRay.transform.eulerAngles.z);
            thrust = 0f;
            waterLaunchPoint.transform.eulerAngles = waterArcRotation;
        }
        if (Input.GetMouseButton(0))
        {
            thrust += Time.deltaTime * 15;

           

            Vector3 direction = endRay.transform.position - waterLaunchPoint.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            waterLaunchPoint.transform.rotation = Quaternion.Lerp(waterLaunchPoint.transform.rotation, rotation, speed * Time.deltaTime);

            RaycastVoid();

        }
        if (Input.GetMouseButtonUp(0))
        {
            waterLaunchPoint.transform.eulerAngles = waterArcRotation;
            thrust = 0f;
            waterParticles[0].SetActive(false);
            waterParticles[1].SetActive(false);
      
            hitTorch = false;
        }
    }

    public Vector3 waterPartVector;
    public RaycastHit hit;
    public Color color;
    public bool hitTorch;
  
    void RaycastVoid()
    {

        

        Debug.DrawRay(waterLaunchPoint.transform.position, waterLaunchPoint.transform.forward, color, thrust);
        if (Physics.Raycast(waterLaunchPoint.transform.position, waterLaunchPoint.transform.forward, out hit, thrust))
        {
            waterPartVector = hit.point;

            waterParticles[0].SetActive(true);

            if (hit.collider.tag == "Untagged")
            {
               
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

            if (hit.collider.tag == "Burning") 
            {
             
                
                
                
                
                    Debug.Log("burn");

                    torch = hit.collider.gameObject.GetComponent<Torch>();
                    switch (cT.torch)
                    {
                        case 1:
                            cT.torch -= 1;
                            //changing the layer prevents torches from being extinguishable twice
                            torch.gameObject.tag = "Torch";
                            torch.gameObject.layer = 0;
                            torch.hitWithWater = true;
                            cT.onFire[0] = false;
                            break;
                        case 2:
                            cT.torch -= 1;
                            torch.gameObject.tag = "Torch";
                            torch.gameObject.layer = 0;
                            torch.hitWithWater = true;
                            cT.onFire[1] = false;
                            break;
                        case 3:
                            cT.torch -= 1;
                            torch.gameObject.tag = "Torch";
                            torch.gameObject.layer = 0;
                            torch.hitWithWater = true; 
                            cT.onFire[2] = false;
                            break;
                        case 4:
                            cT.torch -= 1;
                            torch.gameObject.tag = "Torch";
                            torch.gameObject.layer = 0;
                            torch.hitWithWater = true;
                            cT.onFire[3] = false;
                            break;
                    


                    
                }
                
            }

           
        }
        else
        {
            waterParticles[0].SetActive(false);
        }

    }
}
