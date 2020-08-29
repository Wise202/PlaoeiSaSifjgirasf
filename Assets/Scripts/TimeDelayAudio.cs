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
        WalkingSounds();
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

    public float walkingSpeed;
    public int walkingCount;
    bool walk;


    public AudioClip[] footsteps;
    void WalkingSounds() 
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walkingSpeed += Time.deltaTime;
            if (walkingSpeed >= 0.4f) 
            {
                walkingCount++;
                walk = true;
                walkingSpeed = 0f;
            }
            switch (walkingCount) 
            {
                case 1:

                    walkingSource.clip = footsteps[0];
                    if (walk) 
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 2:
                    walkingSource.clip = footsteps[1];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 3:
                    walkingSource.clip = footsteps[2];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 4:
                    walkingSource.clip = footsteps[3];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 5:
                    walkingSource.clip = footsteps[4];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 6:
                    walkingSource.clip = footsteps[5];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 7:
                    walkingSource.clip = footsteps[6];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 8:
                    walkingSource.clip = footsteps[7];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 9:
                    walkingSource.clip = footsteps[8];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 10:
                    walkingSource.clip = footsteps[9];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 11:
                    walkingSource.clip = footsteps[10];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 12:
                    walkingSource.clip = footsteps[11];
                    if (walk)
                    {
                        walkingSource.Play();
                        walk = false;
                    }
                    break;
                case 13:
                    walkingCount = 1;
                    break;

                default:

                    break;
            }

        }





    }
}
