using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Torch : MonoBehaviour
{

    public CheckTorch cT;
    public BoxCollider boxCol;
    public GameObject fire;


    

    void OnTriggerEnter(Collider col)
    {

        //Checks the game objects tag andif the torch is not burning will turn on flame
        //and sets the Torch on count up by 1
        if (col.gameObject.tag == "Flame")
        {
            
            switch (cT.torch)
            {
                case 0:
                    cT.torch += 1;
                    //changing the layer prevents torches from being lit twice 
                    this.gameObject.layer = 8;
                    //setting this active lights the flame turning on the fire
                    fire.SetActive(true);
                    cT.onFire[0] = true;
                    break;
                case 1:
                    cT.torch += 1;
                    this.gameObject.layer = 8;
                    fire.SetActive(true);
                    cT.onFire[1] = true;
                    break;
                case 2:
                    cT.torch += 1;
                    this.gameObject.layer = 8;
                    fire.SetActive(true);
                    cT.onFire[2] = true;
                    break;
                case 3:
                    cT.torch += 1;
                    this.gameObject.layer = 8;
                    fire.SetActive(true);
                    cT.onFire[3] = true;
                    break;
            }
            
        }

        if (col.gameObject.tag == "Water")
        {
            //Checks the game objects tag and if the torch object is already burning will turn off flame
            //and set the Torch on count down by 1
            switch (cT.torch)
            {
                case 1:
                    cT.torch -= 1;
                    //changing the layer prevents torches from being extinguished twice
                    this.gameObject.layer = 0;
                    fire.SetActive(false);
                    cT.onFire[0] = false;
                    break;
                case 2:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    fire.SetActive(false);
                    cT.onFire[1] = false;
                    break;
                case 3:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    fire.SetActive(false);
                    cT.onFire[2] = false;
                    break;
                case 4:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    fire.SetActive(false);
                    cT.onFire[3] = false;
                    break;
            }
        }

    }

}
