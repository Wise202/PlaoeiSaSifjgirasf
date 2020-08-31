using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip c;
    public GameObject loading;
    public GameObject player;
    

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) 
        {
            player.SetActive(false);
            loading.SetActive(true);
            SceneManager.LoadSceneAsync("Lvl1Final", LoadSceneMode.Single);
        }
        
    }
}
