using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TimeDelayAudio : MonoBehaviour
{

    public AudioSource voiceLineSource;
    public AudioSource walkingSource;
    public AudioClip controlClip;
    public AudioClip cutRope;
    bool cutRopeSound;
    public AudioClip cutRopeExit;
    bool cutRopeExitSound;
    public AudioClip walkWall;
    bool walkWallBool;
    public AudioClip fakespin;
    bool fakeSpinBool;


    public bool[] controls;
    public bool[] contAudBool;
    public AudioClip[] contAudio;

    public Level1Cont lvl;

    // Start is called before the first frame update
    void Start()
    {

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
        ControlCheck();
    }
    public float contTimer = 30f;
    void ControlCheck()
    {
        contTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A)) { controls[0] = false; }
        if (Input.GetKeyDown(KeyCode.S)) { controls[1] = false; }
        if (Input.GetKeyDown(KeyCode.D)) { controls[2] = false; }
        if (Input.GetKeyDown(KeyCode.W)) { controls[3] = false; }
        if (Input.GetKeyDown(KeyCode.LeftControl)) { controls[4] = false; }
        if (Input.GetKeyDown(KeyCode.E)) { controls[5] = false; }
        if (Input.GetMouseButtonDown(0)) { controls[6] = false; }
        if (Input.GetMouseButtonDown(1)) { controls[7] = false; }
        if (controls[0] || controls[1] || controls[2] || controls[3] || controls[4] || controls[5] || controls[6] || controls[7]) 
        {
            if (contTimer <= 0 && !voiceLineSource.isPlaying) { controls[8] = true; }
        
        }
        if (!controls[7] && contTimer >= 0 && !voiceLineSource.isPlaying && !contAudBool[0]) 
        {
            voiceLineSource.clip = contAudio[0];
            voiceLineSource.Play();
            contAudBool[0] = true;
        }

        if (!controls[6] && contTimer >= 0 && !voiceLineSource.isPlaying && !contAudBool[1]) 
        {
            voiceLineSource.clip = contAudio[1];
            voiceLineSource.Play();
            contAudBool[1] = true;
        }
       



        if (controls[8] && !controls[9]) 
        {
            voiceLineSource.clip = controlClip;
            voiceLineSource.Play();
            controls[9] = true;
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13 && !walkWallBool && !voiceLineSource.isPlaying) 
        {

            voiceLineSource.clip = walkWall;
            voiceLineSource.Play();
            walkWallBool = true;
        }
    }
}
