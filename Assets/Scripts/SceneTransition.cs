using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public GameObject player;
    public string puzzleName;
    bool changeSize;
    public float time;



  


    private void FixedUpdate()
    {
        if (changeSize) 
        {
            switch (puzzleName)
            {
                case "Torch":
                    transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime;
                    time -= Time.deltaTime;
                    break;

                default: 
                    changeSize = false;
                    puzzleName = null;
                    break;
            }
        }
        if (time <= 0) 
        {
            SceneManager.LoadScene(puzzleName, LoadSceneMode.Single);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Torch" && Input.GetKeyDown(KeyCode.E)) 
        {
            puzzleName = other.gameObject.name;
            changeSize = true;
        }
    }




}
