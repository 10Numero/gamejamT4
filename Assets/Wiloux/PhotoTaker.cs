using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTaker : MonoBehaviour
{
    public PastCamPic cam2;
    public Animator anim;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("CamOn", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                cam2.CallTakeSnap();
            }
        }
        else
        {
            anim.SetBool("CamOn", false);
        }
    }
}
