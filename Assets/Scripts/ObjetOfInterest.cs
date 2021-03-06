﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetOfInterest : MonoBehaviour
{
    public int GameState = 0;
    public int InterestState = 0;

    public GameObject cam2;
    public GameObject GM;
    private DialogueManager DM;
    public GameObject Comment; 
    private Dialogue CommentDialogue;
    public AudioSource audioS;

    private Renderer rend;
    public bool isVisible = false;
    public bool isReady = false;
    public bool HasBeenPhotographed;
    public bool cantBePhotographed = true;

    // Update is called once per frame

    private void Awake()
    {
        DM = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        rend = GetComponent<Renderer>();
        GM = GameObject.FindGameObjectWithTag("GM");
        cam2 = GameObject.FindGameObjectWithTag("PastCam");
        CommentDialogue = Comment.GetComponent<DialogueTrigger>().dialogue;
    }

    private void Update()
    {

    }
    void LateUpdate()
    {
        if (cam2 != null)
        {
            isReady = true;
        }


        GameState = GM.GetComponent<GM>().GameState;

        if (GameState >= InterestState && !HasBeenPhotographed && !cantBePhotographed && !audioS.isPlaying)
        {
            I_Can_See();
            if (cam2.activeInHierarchy && isReady)
            {
                if (isVisible)
                {
                    HasBeenPhotographed = true;
                    GM.GetComponent<GM>().PhotographedObjects.Add(gameObject);
                    GM.GetComponent<GM>().GameState++;
                    if (Comment != null) {
                        DM.StartDialogue(CommentDialogue);
                    }
                    isReady = false;
                }
            }
        }


        else
        {
        }

    }
    public void I_Can_See()
    {
       
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam2.GetComponent<Camera>());
        if (GeometryUtility.TestPlanesAABB(planes, gameObject.GetComponent<Collider>().bounds) && !Physics.Linecast(gameObject.transform.position, GM.transform.position))
            isVisible = true;
        else
            isVisible = false;
    }

}
