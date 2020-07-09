using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Water : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust;
    public CastingScript1 cS1;

    private void Awake()
    {
        cS1 = GameObject.Find("Player Camera").GetComponent<CastingScript1>();
        thrust = cS1.thrust;

    }

    private void Start()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }


}
