using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    public CheckTorch cT;
    public BoxCollider boxCol;


    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Flame")
        {

            switch (cT.torch)
            {
                case 0:
                    cT.torch += 1;
                    this.gameObject.layer = 10;
                    cT.onFire[0] = true;
                    break;
                case 1:
                    cT.torch += 1;
                    this.gameObject.layer = 10;
                    cT.onFire[1] = true;
                    break;
                case 2:
                    cT.torch += 1;
                    this.gameObject.layer = 10;
                    cT.onFire[2] = true;
                    break;
                case 3:
                    cT.torch += 1;
                    this.gameObject.layer = 10;
                    cT.onFire[3] = true;
                    break;
            }
            
        }

        if (col.gameObject.layer == 11)
        {
            switch (cT.torch)
            {
                case 1:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    cT.onFire[0] = false;
                    break;
                case 2:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    cT.onFire[1] = false;
                    break;
                case 3:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    cT.onFire[2] = false;
                    break;
                case 4:
                    cT.torch -= 1;
                    this.gameObject.layer = 0;
                    cT.onFire[3] = false;
                    break;
            }
        }

    }

}
