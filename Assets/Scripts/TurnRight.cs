using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : MonoBehaviour
{

    float speed = 50.0f;
    public Level1Cont l1C;
    float speedBack = 300.0f;
    float backTimer = 1.8f;

    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (l1C.spin)
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
            backTimer = 1f;
        }
        if (l1C.spinBack)
        {
            l1C.spin = false;
            transform.Rotate(Vector3.left * speedBack * Time.deltaTime);
            backTimer -= Time.deltaTime;
        }

        if (backTimer <= 0)
        {
            l1C.spinBack = false;
            
        }
    }
}
