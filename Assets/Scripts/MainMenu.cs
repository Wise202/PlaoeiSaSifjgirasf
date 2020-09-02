using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MainMenu : MonoBehaviour
{

    public AudioClip[] sceneAudio;
    public AudioSource source;

 //   public float audioCountdown = 2f;
    public bool[] audioCheck;

    public GameObject title;
    public GameObject credits;
    public GameObject loadingScreen;

   


    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //if (!source.isPlaying)
        //{
        //    audioCountdown -= Time.deltaTime;
        //}



        //if (!audioCheck[0] && audioCountdown <= 0)
        //{
        //    source.clip = sceneAudio[1];
        //    source.Play();
        //    audioCountdown = 20f;
        //    audioCheck[1] = true;
        //    audioCheck[0] = true;
        //}

        //if (audioCheck[1] && audioCountdown <= 0)
        //{
        //    source.clip = sceneAudio[2];
        //    source.Play();
        //    audioCountdown = 20f;

        //    audioCheck[1] = false;
        //    audioCheck[2] = true;
        //}

        //if (audioCheck[2] && audioCountdown <= 0) 
        //{
        //    source.clip = sceneAudio[0];
        //    source.Play();
        //    audioCountdown = 20f;
        //    audioCheck[0] = false;
        //    audioCheck[1] = false;
        //    audioCheck[2] = false;
        //}





    }

    public void PlayGame() 
    {
        loadingScreen.SetActive(true);
        source.Stop();
        title.SetActive(false);

        SceneManager.LoadSceneAsync("Intro");
    }

    public void LoadCredits() 
    {
        title.SetActive(false);
        credits.SetActive(true);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    public void LoadMenu() 
    {
        credits.SetActive(false);
        title.SetActive(true);
    }
}
