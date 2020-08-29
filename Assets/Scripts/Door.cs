using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Light pl;
    public float pIntensity;

    public AudioSource door;
    public AudioClip up;
    public AudioClip down;

    public float intensity 
    {
        set 
        {
            if (value < 0f)
            {
                pIntensity = 0f;
            }
            else if (value > 5f)
            {
                pIntensity = 5f;
            }
            else 
            {
                pIntensity = value;
            }
        }
        get { return pIntensity; }
    }
    public bool doorUp;



    private void Update()
    {

        pl.intensity = intensity;
        if (doorUp)
        {
            intensity += Time.deltaTime * 2;
        }
        else 
        {
            intensity -= Time.deltaTime * 2;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "UpTag") 
        {
            doorUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "UpTag") 
        {
            doorUp = false;
        }
        if (other.gameObject.name == "DownTag") 
        {
            door.clip = down;
            door.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "UpTag") 
        {
            door.clip = up;
            door.Play();
        }
    }


}
