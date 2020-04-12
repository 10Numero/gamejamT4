using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDialog : MonoBehaviour
{
    
    public GameObject talkAid;
    public GameObject letterToRead;
    public AudioSource audioS;

    public GameObject doorWilliam;

    public GameObject pastBedRobert;

    public Dialogue[] commentsPresent;
    public Dialogue[] recaps;

    private bool lookAtBody = false;
    private bool[] examination1 = new bool[6];
    private bool[] examination2 = new bool[5];

    private bool doOnce = false;

    public bool firstCondition = false;
    public bool secondCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        talkAid.SetActive(false);
        letterToRead.SetActive(false);

        for(int i = 0; i < examination1.Length; i++)
        {
            examination1[i] = false;
        }

        for (int j = 0; j < examination2.Length; j++)
        {
            examination2[j] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (examination1[0] && examination1[1] && examination1[2] && examination1[3] && examination1[4] && examination1[5] && examination1[6])
        {
            firstCondition = true;
        }

        if (examination2[0] && examination2[1] && examination2[2] && examination2[3])
        {
            secondCondition = true;
        }
        
        //if (secondCondition)
        //{
        //    doorWilliam.transform.rotation = Quaternion.Euler(doorWilliam.transform.rotation.z, doorWilliam.transform.rotation.x, -161.3f);
        //    doorWilliam.transform.position = new Vector3(2.101f, doorWilliam.transform.position.y, doorWilliam.transform.position.z);
        //}
        
        if (examination1[2] && examination1[3] && examination1[4] && pastBedRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            if (!audioS.isPlaying && !doOnce)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[0]);
                doOnce = true;
            }
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Body") && !lookAtBody)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[3]);
            lookAtBody = true;
        }

        else if (collider.gameObject.CompareTag("LunchTable") && firstCondition)
        {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[16]);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[0]);
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[1]);
                examination1[0] = true;

            }

        }

        else if (collider.gameObject.CompareTag("Suitcase"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[2]);
                examination1[1] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Body"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[4]);
                examination1[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("BlueLips"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[5]);
                examination1[4] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Kit"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[6]);
                examination1[5] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Pills"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[7]);
                examination1[6] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Vomi"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[8]);
                examination1[3] = true;
            }

        }

        else if (collider.gameObject.CompareTag("LockedSuitcase") && secondCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[9]);
            }

        }

        else if (collider.gameObject.CompareTag("Letter") && secondCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                letterToRead.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[10]);
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                letterToRead.SetActive(false);
            }

        }

        else if (collider.gameObject.CompareTag("Tissue") && secondCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[11]);
            }

        }

        else if (collider.gameObject.CompareTag("LampLessTable") && firstCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[12]);
                examination2[0] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Poker") && firstCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[13]);
                examination2[1] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Bar") && firstCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[14]);
                examination2[4] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Rack"))
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[15]);
            }

        }

        else if (collider.gameObject.CompareTag("Carpet") && firstCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[17]);
                examination2[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto2") && firstCondition)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[18]);
                examination2[5] = true;
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
            letterToRead.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Tissue"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LampLessTable"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Poker"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Bar"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Rack"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LunchTable"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Carpet"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

    }
}
