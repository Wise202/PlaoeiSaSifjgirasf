using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Water : MonoBehaviour
{
    public CastingScript1 cS1;

    private void Awake()
    {
        

    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position = cS1.waterPartVector;
        transform.LookAt(cS1.gameObject.transform);
    }


}
