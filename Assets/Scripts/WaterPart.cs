using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class WaterPart : MonoBehaviour
{
    public CastingScript1 cS1;
    public string lol;

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
        lol = cS1.hit.collider.tag;
    }


}
