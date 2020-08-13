using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoor : MonoBehaviour
{
    public Animation anim;
    public AnimationClip up;
    public AnimationClip down;
    public bool l;
    public Plate p;

    // Update is called once per frame
    void Update()
    {
        //if (p.nothingOn) 
        //{
        //    anim.clip = up;
        //    anim.Play();
        //}

        if (!p.nothingOn && l)
        {
            anim.clip = down;
            anim.Play();
        }

    }

    public void SetFalse() 
    {
        l = false;
    }
}
