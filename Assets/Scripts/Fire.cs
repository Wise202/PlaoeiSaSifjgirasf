using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //this script lights the torches in the scene with a fireball that works like a normal
    //sphere
    public GameObject fireAnim;

    public Torches torches;



    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
       
            if (collision.gameObject.name == "Torch1" && !torches.lit[0])
            {

                //Instantiate(fireAnim, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.5f, collision.transform.position.z + -0.5f), Quaternion.identity);
                torches.lit[0] = true;
            }
            if (collision.gameObject.name == "Torch2" && !torches.lit[1])
            {
                //Instantiate(fireAnim, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.5f, collision.transform.position.z + -0.5f), Quaternion.identity);
                torches.lit[1] = true;
            }
            if (collision.gameObject.name == "Torch3" && !torches.lit[2])
            {
                //Instantiate(fireAnim, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.5f, collision.transform.position.z + -0.5f), Quaternion.identity);
                torches.lit[2] = true;
            }
            if (collision.gameObject.name == "Torch4" && !torches.lit[3])
            {
                //Instantiate(fireAnim, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.5f, collision.transform.position.z + -0.5f), Quaternion.identity);
                torches.lit[3] = true;
            }
        
    }
}
