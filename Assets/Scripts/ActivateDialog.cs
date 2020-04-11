﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDialog : MonoBehaviour
{
    
    public GameObject talkAid;
    public Dialogue[] dialogue;

    private bool lookAtBody = false;

    // Start is called before the first frame update
    void Start()
    {
        talkAid.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Body") && !lookAtBody)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[3]);
            lookAtBody = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[0]);
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
            }

        }

        else if (collider.gameObject.CompareTag("Suitcase"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[2]);
            }

        }

        else if (collider.gameObject.CompareTag("Body"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[4]);
            }

        }

        else if (collider.gameObject.CompareTag("BlueLips"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[5]);
            }

        }

        else if (collider.gameObject.CompareTag("Kit"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[6]);
            }

        }

        else if (collider.gameObject.CompareTag("Pills"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[7]);
            }

        }

        else if (collider.gameObject.CompareTag("Bottles"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[8]);
            }

        }

        else if (collider.gameObject.CompareTag("Vomi"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[9]);
            }

        }

        else if (collider.gameObject.CompareTag("LockedSuitcase"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[10]);
            }

        }

        else if (collider.gameObject.CompareTag("Letter"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[11]);
            }

        }

        else if (collider.gameObject.CompareTag("Tissue"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[12]);
            }

        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("EliPhoto"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Suitcase"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Body"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("BlueLips"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Kit"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Pills"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Bottles"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Vomi"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LockedSuitcase"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Letter"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Tissue"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

    }
}
