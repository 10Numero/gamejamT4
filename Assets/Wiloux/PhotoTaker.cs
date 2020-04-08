using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTaker : MonoBehaviour
{
    public PastCamPic cam2;
    public Animator anim;
    public Animator anim2;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("CamOn", true);
            if (Input.GetKeyDown(KeyCode.Mouse0) && anim2.GetCurrentAnimatorStateInfo(0).IsName("Void"))
            {
                cam2.CallTakeSnap();
                anim2.SetTrigger("Flash");
            }
        }
        else
        {
            anim.SetBool("CamOn", false);
        }
    }

}
