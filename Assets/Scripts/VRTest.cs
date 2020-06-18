using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class VRTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Boolean grabAction;



    //put update here
    private void Update()
    {
        if (getTeleportDown())
        {
            print("Teleport" + handType);
        }
        if (getGrab())
        {
            print("Grab " + handType);
        }
    }


    public bool getTeleportDown()
    {
        return teleportAction.GetStateDown(handType);
    }

    public bool getGrab()
    {
        return grabAction.GetState(handType);
    }

}
