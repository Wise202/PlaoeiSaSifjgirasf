using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Cont : MonoBehaviour
{

    public bool spin;
    public bool badBrazier;
    public AudioClip badAud;
    public AudioSource source;
    bool badBrazAud;
    public bool goodBrazier;
    public AudioClip gBrazAud;
    int gBrazInt;
    public bool fakeBrazier;
    public bool spinBack;
    public float hitFireCount = 2.5f;
    bool stopHitFireCount;

    public int woodCount;
    public Animator anim;
    

    public Jug j;
    public bool hasWater;
    public AudioClip noWater;
    bool noWaterBool;
    public bool jugInPlace;
    public bool cutRope;

    // Update is called once per frame
    void Update()
    {
        if (source.clip == badAud && !badBrazAud && !source.isPlaying) 
        {
            source.Play();
            badBrazAud = true;
        }
        if (hasWater && jugInPlace)
        {
            OpenDoor();
        }

        if (j.isFilled)
        {
            hasWater = true;
        }

        else
        {
            hasWater = false;
        }

        if (woodCount >= 1)
        {
            fakeBrazier = true;
        }

        if (woodCount <= 0)
        {
            fakeBrazier = false;
        }

        if ( !jugInPlace || !hasWater ) 
        {
            if (spin)
            {
                anim.SetBool("Open", false);
                hitFireCount = -1f;
            }
        }
        if (hitFireCount <= 0)
        {
            spinBack = true;
            //exitDoor.useGravity = true;
            if (!badBrazier)
            {
                hitFireCount = 0.1f;
            }
            if (badBrazier)
            {
                hitFireCount = 0.5f;
            }
        }

       
    }



  
    

    void OpenDoor() 
    {
       
        
        //lifts the main door partway then triggers the reset of it if the player hasnt gotten the good brazier under the jug
        if (spin && !goodBrazier && !fakeBrazier) 
        {

            anim.SetBool("Open", false);
            hitFireCount -= Time.deltaTime;
           
        }
        //lifts the main door fully if the player has the good brazier in place
        if (spin && goodBrazier && !fakeBrazier)
        {
            anim.SetBool("Open", true);

            if (gBrazInt == 0 && !source.isPlaying) 
            {
                source.clip = gBrazAud;
                source.Play();
                gBrazInt++;
            }
            if (cutRope)
            {
                anim.SetBool("Open", false);

                
            }
        }

        if (spin && badBrazier) 
        {
            source.clip = badAud;
            anim.SetBool("badBraz", true);
        }
        if (!spin) 
        {
            anim.SetBool("badBraz", false);
        }
        
        //stops adding force to the main door dropping it back down to its starting position
        //if badBrazier is true the door lifts partway further but still not fully
        //if (hitFireCount <= 0) 
        //{
        //    spinBack = true;
        //    //exitDoor.useGravity = true;
        //    if (!badBrazier)
        //    {
        //        hitFireCount = 2f;
        //    }
        //    if(badBrazier) 
        //    {
        //        hitFireCount = 2.5f;
        //    }
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fireball(Clone)" && jugInPlace && hasWater)
        {
            if (cutRope == false) 
            {
                spin = true;
            }

            
        }

        if (other.gameObject.name == "Fireball(Clone)"  && !hasWater && !noWaterBool && !source.isPlaying) 
        {
            source.clip = noWater;
            source.Play();
            noWaterBool = true;
        }

        if (other.gameObject.name == "BadBrazier") 
        {
            hitFireCount = 2.5f;
        }

        if (other.gameObject.tag == "Wood") 
        {
            woodCount++;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "GoodBrazier")
        {
            goodBrazier = true;
        }
        if (other.gameObject.name == "BadBrazier")
        {
            badBrazier = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BadBrazier") 
        {
            badBrazier = false;
        }
        if (other.gameObject.name == "GoodBrazier") 
        {
            goodBrazier = false;
        }

        if (other.gameObject.tag == "Wood") 
        {
            woodCount--;
        }

    }



}
