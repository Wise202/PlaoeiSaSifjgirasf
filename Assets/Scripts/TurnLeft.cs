using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurnLeft : MonoBehaviour
{
    float speed = 50.0f;
    public Level1Cont l1C;
    float speedBack = 300.0f;
    public float backTimer = 1.8f;
    public AudioSource source;
    bool stopPlayback;
    bool stopAud;

    

    private void Update()
    {
        if (l1C.spin)
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
            backTimer = 1f;
            if (!stopPlayback) 
            {
                source.Play();
                stopPlayback = true;
            }
        }
        if (l1C.spinBack)
        {
            l1C.spin = false;
            transform.Rotate(Vector3.right * speedBack * Time.deltaTime);
            backTimer -= Time.deltaTime;
        }

        if (!l1C.spinBack && !l1C.spin) 
        {
            source.Stop();
            stopPlayback = false;
        }

        if (backTimer <= 0)
        {
            backTimer = 1f;
            l1C.spinBack = false;

        }
    }
}
