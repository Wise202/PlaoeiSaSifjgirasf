using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    float speed = 50f;
    private void FixedUpdate()
    {

        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            Application.Quit();
        }
    }
}
