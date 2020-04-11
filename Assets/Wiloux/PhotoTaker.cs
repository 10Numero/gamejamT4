using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTaker : MonoBehaviour
{
    public PastCamPic cam2;
    public Animator anim;
    public Animator anim2;
    public AudioSource audio;
    public AudioClip SfxFlash;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("CamOn", true);
            if (Input.GetKeyDown(KeyCode.Mouse0) && anim2.GetCurrentAnimatorStateInfo(0).IsName("Void"))
            {
                cam2.CallTakeSnap();
                anim2.SetTrigger("Flash");

                audio.pitch = Random.Range(0.5f, 1.5f);
                audio.PlayOneShot(SfxFlash, 1);
}
        }
        else
        {
            anim.SetBool("CamOn", false);
        }
    }

}
