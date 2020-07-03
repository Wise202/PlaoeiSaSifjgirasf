using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        Sprint();
    }

    void Sprint() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 6f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4f;
        }
    }
}
