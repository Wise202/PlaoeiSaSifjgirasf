using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject ExitDoor;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Earth")
        {
            ExitDoor.SetActive(true);
            print("11");
        }
    }
}
