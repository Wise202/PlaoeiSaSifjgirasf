using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnable : MonoBehaviour
{
    public Hanging h;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)") 
        {
            Destroy(gameObject);
            h.hanging = false;
        }
    }
}
