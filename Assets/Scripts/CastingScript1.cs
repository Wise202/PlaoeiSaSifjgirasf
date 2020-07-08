using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingScript1 : MonoBehaviour
{
    public Transform[] castingPoints;
    public GameObject Fire;

    float xRotation = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(Fire, castingPoints[0].position, Quaternion.identity);
        }

        float posY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

        xRotation -= posY;
        xRotation = Mathf.Clamp(xRotation, 0f, 0f);

    }
}
