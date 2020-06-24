using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRTestController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public GameObject fireball;
    public GameObject firepoint;

    private GameObject collidingObject;
    private GameObject objectinHand;

    private void setCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            Instantiate(fireball, firepoint.transform.position, transform.rotation);
            if (collidingObject)
            {
                GrabObject();
            }
        }
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectinHand)
            {
                ReleaseObject();
            }
        }
    }




    public void OnTriggerEnter(Collider other)
    {
        setCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        setCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
    }

    private void GrabObject()
    {
        objectinHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectinHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectinHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectinHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        objectinHand = null;
    }

}
