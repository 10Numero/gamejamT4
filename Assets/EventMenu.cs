using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMenu : MonoBehaviour
{

    public Animator anim;
    public AudioSource audio;
    public AudioClip wood;
    private bool closer;

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
}
