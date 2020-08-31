using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    float bird = 15;
    public int birdInt;
    // Update is called once per frame
    void Update()
    {
        bird -= Time.deltaTime;

        if (bird <= 0) 
        {
            source.clip = clips[birdInt];
            source.Play();

            birdInt++;
            bird = 15;
        }
        if (birdInt == 3) 
        {
            birdInt = 0;
        }




    }
}
