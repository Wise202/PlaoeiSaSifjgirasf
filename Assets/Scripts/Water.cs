using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Water : MonoBehaviour
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
        return collider.transform.position.y + collider.bounds.size.y;
    }

    private void UpdateStream(float newHeight) 
    {
        Vector3 newPosition = new Vector3(transform.position.x, newHeight, transform.position.z);
        mParticleSystem.position = newPosition;

        newHeight /= transform.localScale.y;
        mMeshRenderer.material.SetFloat("_Cutoff", newHeight);
    }

}
