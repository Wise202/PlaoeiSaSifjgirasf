using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFlame : MonoBehaviour
{
    public MeshRenderer mR;

    public Material orange;
    public Material white;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            
            mR.material = orange;
        }
    }
}
