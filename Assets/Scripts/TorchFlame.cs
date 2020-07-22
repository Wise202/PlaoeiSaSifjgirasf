using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlame : MonoBehaviour
{
    public ParticleSystem fire_Alpha;
    public ParticleSystem fire_Additive;
    public Light light;
    bool startFadeOut;
    public bool hitWithWater;
    public bool startBurning;
    float fadeOutTimer = 2.5f;

    private void Start()
    {
        hitWithWater = true;
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
        if (startBurning) 
        {
            gameObject.SetActive(true);
            fire_Additive.Play();
            fire_Alpha.Play();
            startFadeOut = false;
            fadeOutTimer = 2.5f;

            light.intensity = 0.64f;
            startBurning = false;
        }
        if (hitWithWater)
        {
            //Stop looping the 2 particle effects
            fire_Additive.Stop();
            fire_Alpha.Stop();
            //start their fade out so they dont just destroy all at once
            startFadeOut = true;
            hitWithWater = false;
            
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
            startFadeOut = false;
            
        }
    }


  

}
