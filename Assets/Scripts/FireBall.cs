using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ParticleSystem fire_Alpha;
    public ParticleSystem fire_Additive;
    public Light light;

    //this script is going to add force to the object and throw the fireball
    public Rigidbody rb;
    public float thrust = 10000f;

    public float deathTimeOut = 5f;
    bool startFadeOut;
    float fadeOutTimer = 2.5f;

    private void Start()
    {
        rb.AddRelativeForce(-Vector3.forward * thrust);
        
    }

    private void Update()
    {
        DeathVoids();
    }

    void DeathVoids() 
    {
        deathTimeOut -= Time.deltaTime;
        if (deathTimeOut <= 0)
        {
            fire_Additive.Stop();
            fire_Alpha.Stop();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            startFadeOut = true;
        }
        if (startFadeOut)
        {
            fadeOutTimer -= Time.deltaTime;

        }
        if (fadeOutTimer <= 1.5f) 
        {
            light.intensity -= Time.deltaTime;
        }
        if (fadeOutTimer <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        fire_Additive.Stop();
        fire_Alpha.Stop();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        startFadeOut = true;
    }

}
