using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlanks : MonoBehaviour
{

    public Rigidbody rb;
    public CastingScript1 cS1;
    string hit;

    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        hit = cS1.hit.transform.gameObject.name;

        if (hit == gameObject.name) 
        {
            rb.constraints = RigidbodyConstraints.None;
            Debug.Log("rip");
        }
            
    }
}
