using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class RopeCut2 : MonoBehaviour
{
    public Animator anim;
    public CastingScript1 cS1;
    public string hits;
    public Rigidbody rb;
    public GameObject topPart;
    public GameObject[] bottomPart;
    public Carryable carry;
    bool cut;
    float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //unparenting topPart stops the top part of the rope falling with the brazier haning on the wall
        topPart.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        hits = cS1.hit.transform.gameObject.name;
        if (hits == gameObject.name) 
        {
            anim.enabled = true;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            cut = true;
            Destroy(topPart);
            Destroy(bottomPart[1]);
            carry.enabled = true;
        }
        if(cut == true) 
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0) 
        {
            Destroy(bottomPart[0]);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)") 
        {
            anim.enabled = true;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            cut = true;
            Destroy(topPart);
            Destroy(bottomPart[1]);
            carry.enabled = true;
        }
    }
}
