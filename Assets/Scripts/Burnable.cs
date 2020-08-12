using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    public Hanging h;
    string hit;
    public CastingScript1 cS1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)") 
        {
            Destroy(gameObject);
            h.hanging = false;
        }

    }

    private void Update()
    {
        hit = cS1.hit.transform.gameObject.name;
        if (hit == gameObject.name) 
        {
            h.hanging = false;
            Destroy(gameObject);
        }
    }
}
