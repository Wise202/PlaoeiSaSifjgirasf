using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeDelayAudio : MonoBehaviour
{

    public AudioSource voiceLineSource;
    public AudioSource walkingSource;
    public AudioClip controlClip;
    public AudioClip cutRope;
    bool cutRopeSound;

    public AudioClip fakespin;
    bool fakeSpinBool;


    public Level1Cont lvl;

    // Start is called before the first frame update
    void Start()
    {
        voiceLineSource.clip = controlClip;
        voiceLineSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (voiceLineSource.isPlaying) 
        {
            Debug.Log("playing");
        }

        if (lvl.cutRope && !cutRopeSound) 
        {
            voiceLineSource.clip = cutRope;
            voiceLineSource.Play();
            cutRopeSound = true;
        }
        if (cutRopeSound && !voiceLineSource.isPlaying) 
        {
            SceneManager.LoadScene("Lvl1Final");
        }

        fakebraz();
    }

    void fakebraz() 
    {
        if (lvl.fakeBrazier && lvl.spin && !fakeSpinBool) 
        {
            voiceLineSource.clip = fakespin;
            voiceLineSource.Play();
            fakeSpinBool = true;

        }
        if (fakeSpinBool) 
        {
            if (!voiceLineSource.isPlaying) 
            {
                SceneManager.LoadScene("Lvl1Final");

            }
        }


    }

    float walkingSpeed;
    int walkingCount;


    public AudioClip[] footsteps;
    void WalkingSounds() 
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walkingSpeed += Time.deltaTime;
            if (walkingSpeed >= 0.5f) 
            {
                walkingCount++;
                walkingSpeed = 0f;
            }
            switch (walkingCount) 
            {
                case 1:
                    walkingSource.clip = footsteps[0];
                    walkingSource.Play();
                    break;

                default:

                    break;
            }

        }





    }
}
