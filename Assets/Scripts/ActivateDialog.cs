using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialog : MonoBehaviour
{

    public bool setActivation = false;

    public GameObject talkAid;
    public Dialogue[] dialogue;

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
        if (collider.gameObject.CompareTag("Bar"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[5]);
            }

        }

        else if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("ClosedDoor");
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[0]);
            }

        }

        else if (collider.gameObject.CompareTag("Mouchoir"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[7]);
            }

        }

        else if (collider.gameObject.CompareTag("Lettre"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[6]);
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
            }

        }

        else if (collider.gameObject.CompareTag("Vomi"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[2]);
            }

        }

        else if (collider.gameObject.CompareTag("Body"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[3]);
            }

        }

        else if (collider.gameObject.CompareTag("BlueLips"))
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue[4]);
            }

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bar"))
        {
            talkAid.SetActive(false);
        }

        else if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            talkAid.SetActive(false);
        }
    }
}
