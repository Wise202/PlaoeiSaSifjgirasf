using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
   
    public Animator anim;
    public CastingScript1 cS1;
    public string hits;
    public Level1Cont l1C;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hits = cS1.hit.transform.gameObject.name;
        if (hits == gameObject.name)
        {
            anim.enabled = true;
            l1C.cutRope = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.gameObject.name == "Fireball(Clone)")
        {
            anim.enabled = true;
            Destroy(gameObject);
        }
    }

   
}
