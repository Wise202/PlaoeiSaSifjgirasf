using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    float deathCount = 2f;
    bool deathCheck = false;

    void Update()
    {
        if (deathCheck)
        {
            deathCount -= 1f;
        }

        if (deathCount <= 0)
        {
            
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject)
        {
            deathCheck = true;
        }
    }

}
