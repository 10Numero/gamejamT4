using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMenu : MonoBehaviour
{

    public Animator anim;
    public AudioSource audio;
    public AudioClip wood;
    private bool closer;

    public Animator animCam;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        if (closer == false){
            audio.PlayOneShot(wood, 1);
            closer = true;
        }

       
        anim.SetBool("over_", true);
    }

    void OnMouseExit()
    {
        anim.SetBool("over_", false);
        closer = false;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void EnterSettings()
    {
        animCam.SetBool("inSettings", true);
    }

    public void ExitSettings()
    {
        animCam.SetBool("inSettings", false);
    }

    public void Play()
    {
        //PLAY
    }
}
