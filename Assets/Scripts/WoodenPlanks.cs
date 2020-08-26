using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlanks : MonoBehaviour
{

    public Rigidbody rb;
    public CastingScript1 cS1;
    string hit;
    public Carryable carry;
    public WoodenPlanks wood;
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
            rb.AddRelativeForce(cS1.gameObject.transform.forward * 10f, ForceMode.Impulse);
            carry.enabled = true;
            wood.enabled = false;
        }

      
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)") 
        {
            rb.constraints = RigidbodyConstraints.None;
           
        }
    }
}
