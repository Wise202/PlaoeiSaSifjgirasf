using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Water : MonoBehaviour
{
    public GameObject gO;
    public ValvuePipe vP;


    private void Update()
    {
        if (vP.water)
        {
            gO.SetActive(true);
        }
        if (!vP.water)
        {
            gO.SetActive(false);
        }
    }

}
