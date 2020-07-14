using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StreamScript : MonoBehaviour
{
    public Transform mParticleSystem;

    private MeshRenderer mMeshRenderer;

    private void Awake()
    {
        mMeshRenderer = GetComponent<MeshRenderer>();    
    }

    private void OnTriggerStay(Collider other)
    {
        UpdateStream(GetHeight(other));
    }

    private void OnTriggerExit(Collider other)
    {
        UpdateStream(0);
    }

    private float GetHeight(Collider collider) 
    {
        return collider.transform.position.y + (collider.bounds.size.y / 2);
    }
    private void UpdateStream(float newHeight) 
    {
        //Particle
        Vector3 newPosition = new Vector3(transform.localPosition.x, newHeight, transform.localPosition.z);
        mParticleSystem.localPosition = newPosition;

        

        //Height cutoff
        newHeight /= transform.localScale.y;
        mMeshRenderer.material.SetFloat("_Cutoff", newHeight);
    }

}
