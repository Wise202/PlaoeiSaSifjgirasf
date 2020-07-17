using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererTest : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject S;
    public GameObject E;
    // Start is called before the first frame update
    void Start()
    {
        //lr = GetComponent<LineRenderer>();
        
        lr.SetPosition(0, new Vector3(0,0,0));
        lr.SetPosition(1, new Vector3(0,0,20));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lr.enabled = !lr.enabled;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = !lr.enabled;
        }
    }
}
