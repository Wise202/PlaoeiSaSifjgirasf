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


            if (this.gameObject.name == "T1")
            {
                boxCol.enabled = false;
            }
            if (this.gameObject.name == "T2")
            {
                boxCol.enabled = false;
            }
            if (this.gameObject.name == "T3")
            {
                boxCol.enabled = false;
            }
            if (this.gameObject.name == "T4")
            {
                boxCol.size = new Vector3(0,0,0);
            }

            switch (cT.torch)
            {
                case 0:
                    cT.torch = 1;
                    
                    cT.onFire[0] = true;
                    break;
                case 1:
                    cT.torch = 2; 
                    cT.onFire[1] = true;
                    break;
                case 2:
                    cT.torch = 3;
                    cT.onFire[2] = true;
                    break;
                case 3:
                    cT.torch = 4;
                    cT.onFire[3] = true;
                    break;
            }
            
        }


    }

}
