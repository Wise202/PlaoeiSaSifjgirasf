using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCut : MonoBehaviour
{
    public GameObject rope;
    public Animator anim;
    public CastingScript1 cS1;
    public string hits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hits = cS1.hit.transform.gameObject.name;
        if (hits == rope.name) 
        {
            anim.enabled = true;
            Destroy(rope);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Fireball(Clone)") 
        {
            anim.enabled = true;
        }
    }
}
