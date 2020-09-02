using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenLvl1 : MonoBehaviour
{
    public GameObject player;
    float loadCheck = 0.5f;
    

    // Update is called once per frame
    void Update()
    {
        loadCheck -= Time.deltaTime;

        if (loadCheck <= 0) 
        {
            player.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}
