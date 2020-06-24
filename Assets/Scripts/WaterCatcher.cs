using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCatcher : MonoBehaviour
{
    public GameObject waterPool;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Water")
        {
            waterPool.SetActive(true);
        }
    }

}
