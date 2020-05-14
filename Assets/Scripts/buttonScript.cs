using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class buttonScript : MonoBehaviour
{
    public SteamVR_Action_Boolean SphereOnOff;
    public SteamVR_Input_Sources handType;
    public GameObject sphere;


    void Start()
    {
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger us up");
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) 
    {
        Debug.Log("Trigger is down");
        Instantiate(sphere, transform.position, transform.rotation);
    }

}
