using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchRenderer : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField]
    private float velocityPrivate;
    public float velocity
    {
        set
        {
            if (value < 0f)
            {
                velocityPrivate = 0f;
            }
            else if (value > 80f)
            {
                velocityPrivate = 80f;
            }
            else
            {
                velocityPrivate = value;
            }
        }
        get { return velocityPrivate; }
    }

    [SerializeField]
    private float anglePrivate;
    public float angle
    {
        set
        {
            if (value < 0f)
            {
                anglePrivate = 0f;
            }
            else if (value > 85f)
            {
                anglePrivate = 85f;
            }
            else
            {
                anglePrivate = value;
            }
        }
        get { return anglePrivate; }
    }

    public int resolution = 10;

    float g; //force of gravity on the y axis
    float radianAngle;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }

    private void Start()
    {
        RenderArc();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RenderArc();
            angle += Time.deltaTime * 90;
            velocity += Time.deltaTime * 50;
        }
        if (Input.GetMouseButtonUp(0))
        {
            angle = 0.01f;
            velocity = 0.01f;
            RenderArc();
        }

    }

    //populating the lineRenderer with the appropriate settings
    void RenderArc()
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray());
    }


    //create an array of vector3 positions for arc
    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    //calculate height and distance of each vertex 
    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }

}
