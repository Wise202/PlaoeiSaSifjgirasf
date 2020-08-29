using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ParticleSystem fire_Alpha;
    public ParticleSystem fire_Additive;
    public Light light;
    public BoxCollider bCol;

    public AudioSource aS;
    //this script is going to add force to the object and throw the fireball
    public Rigidbody rb;
    public float thrust = 10000f;

    public float deathTimeOut = 5f;
    bool startFadeOut;
    public bool hitWithWater;
    float fadeOutTimer = 2.5f;

    private void Start()
    {
        rb.AddRelativeForce(-Vector3.forward * thrust);
    }

    private void Update()
    {
        DeathVoids();
    }


    /*death voids destroys the gameobject but before it does that it sets the
    particle systems to fade out and the lights intensity to decrease so that
    the cut off of particle effects isnt so sudden and it looks more natural*/ 
    void DeathVoids() 
    {
        deathTimeOut -= Time.deltaTime;
        if (deathTimeOut <= 0 || hitWithWater)
        {
            //Stop looping the 2 particle effects
            fire_Additive.Stop();
            fire_Alpha.Stop();
            //Stop their movement so they dont continue to move
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            //start their fade out so they dont just destroy all at once
            startFadeOut = true;
            //turn off the box collider so that a dying fireball wont relight a torch
            bCol.enabled = !bCol.enabled;
        }
        if (startFadeOut)
        {
            fadeOutTimer -= Time.deltaTime;

        }
        if (fadeOutTimer <= 2f) 
        {
            light.intensity -= Time.deltaTime;
            aS.volume -= Time.deltaTime;
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
