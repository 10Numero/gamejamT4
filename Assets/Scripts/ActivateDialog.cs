using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDialog : MonoBehaviour
{
    
    public GameObject talkAid;
    public GameObject letterToRead;
    [Space(10)]
    public AudioSource audioS;
    [Space(10)]
    public GameObject closedDoorWilliam;
    public GameObject opendedDoorWilliam;
    [Space(10)]
    public GameObject pastBedRobert;
    public GameObject pastAlliance;
    public GameObject pastIntactBottle;
    public GameObject pastPokerTable;
    public GameObject pastVestRobert;
    public GameObject pastCarpet;
    public GameObject pastSuitcase;
    public GameObject pastTableBrokenLamp;
    [Space(10)]
    public Dialogue[] commentsPresent;
    public Dialogue[] recaps;
    public Dialogue openDoor;

    private bool lookAtBody = false;
    private bool[] examination1 = new bool[6];
    private bool[] examination2 = new bool[4];
    private bool[] examination3 = new bool[3];

    private bool doOnceDoorNoise = false;
    private bool[] doOnceRecap = new bool[7];
    [Space(10)]
    public bool firstCondition = false;
    public bool firstConditionPast = false;
    public bool secondCondition = false;
    public bool secondConditionPast = false;

    // Start is called before the first frame update
    void Start()
    {
        talkAid.SetActive(false);
        letterToRead.SetActive(false);
        closedDoorWilliam.SetActive(true);
        opendedDoorWilliam.SetActive(false);

        //firstCondition = false;
        //firstConditionPast = false;
        //secondCondition = false;
        //secondConditionPast = false;

        doOnceDoorNoise = false;

        for (int i = 0; i < doOnceRecap.Length; i++)
        {
            doOnceRecap[i] = false;
        }

        for (int i = 0; i < examination1.Length; i++)
        {
            examination1[i] = false;
        }

        for (int i = 0; i < examination2.Length; i++)
        {
            examination2[i] = false;
        }

        for (int i = 0; i < examination3.Length; i++)
        {
            examination3[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Deblocage de l'examination du wagon bar
        if (examination1[0] && examination1[1] && examination1[2] && examination1[3] && examination1[4] && examination1[5] && examination1[6])
        {
            firstCondition = true;
        }

        // Deblocage de la chambre de William
        if (examination2[0] && examination2[1] && examination2[2] && examination2[3] && examination2[4])
        {
            secondCondition = true;
        }

        if (pastBedRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed && 
            pastAlliance.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastIntactBottle.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            firstConditionPast = true;
            pastTableBrokenLamp.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastPokerTable.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastVestRobert.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastCarpet.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
        }

        if (pastTableBrokenLamp.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastPokerTable.GetComponent<ObjetOfInterest>().HasBeenPhotographed
            && pastVestRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastCarpet.GetComponent<ObjetOfInterest>().HasBeenPhotographed && firstConditionPast)
        {
            secondConditionPast = true;
        }
        
        if (secondCondition)
        {
            closedDoorWilliam.SetActive(false);
            opendedDoorWilliam.SetActive(true);

            if (!audioS.isPlaying && !doOnceDoorNoise)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(openDoor);
                StartCoroutine(DoorOpened());
                doOnceDoorNoise = true;
            }
        }
        
        // Recap 1
        if (examination1[2] && examination1[3] && examination1[4] && pastBedRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            if (!audioS.isPlaying && !doOnceRecap[0])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[0]);
                doOnceRecap[0] = true;
            }
        }
        
        // Recap 2
        if (firstCondition && doOnceRecap[0] && pastAlliance.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastIntactBottle.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            if (!audioS.isPlaying && !doOnceRecap[1])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[1]);
                doOnceRecap[1] = true;
            }
        }

        // Recap 3
        if (pastPokerTable.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastVestRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed && firstConditionPast)
        {
            if (!audioS.isPlaying && !doOnceRecap[2])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[2]);
                doOnceRecap[2] = true;
            }
        }
        
        // Recap 4
        if (examination2[2] && pastCarpet.GetComponent<ObjetOfInterest>().HasBeenPhotographed && firstConditionPast)
        {
            if (!audioS.isPlaying && !doOnceRecap[3])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[3]);
                doOnceRecap[3] = true;
            }
        }

        // Recap 5
        //if ()
        //{
        //    if (!audioS.isPlaying && !doOnceRecap[4])
        //    {
        //        FindObjectOfType<DialogueManager>().StartDialogue(recaps[4]);
        //        doOnceRecap[4] = true;
        //    }
        //}

        // Recap 6
        //if ()
        //{
        //    if (!audioS.isPlaying && !doOnceRecap[5])
        //    {
        //        FindObjectOfType<DialogueManager>().StartDialogue(recaps[5]);
        //        doOnceRecap[5] = true;
        //    }
        //}

        // Recap 7
        if (doOnceRecap[1] && doOnceRecap[2] && doOnceRecap[3] && secondCondition && secondConditionPast)
        {
            if (!audioS.isPlaying && !doOnceRecap[6])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[6]);
                doOnceRecap[6] = true;
            }
        }

        // Recap 8
        if (examination3[0] && examination3[1] && examination3[2] && examination3[3] 
            && pastSuitcase.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            if (!audioS.isPlaying && !doOnceRecap[7])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[7]);
                doOnceRecap[7] = true;
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
            examination2[3] = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClosedDoor") && !audioS.isPlaying)
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

        else if (collider.gameObject.CompareTag("Body") && !audioS.isPlaying)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[4]);
                examination1[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("BlueLips") && !audioS.isPlaying)
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

        else if (collider.gameObject.CompareTag("LockedSuitcase") && secondCondition && secondConditionPast)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[9]);
                examination3[0] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Letter") && secondCondition && secondConditionPast)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                letterToRead.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[10]);
                examination3[1] = true;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                letterToRead.SetActive(false);
            }

        }

        else if (collider.gameObject.CompareTag("Tissue") && secondCondition && secondConditionPast)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[11]);
                examination3[2] = true;
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

        else if (collider.gameObject.CompareTag("EliPhoto2") && secondCondition && secondConditionPast)
        {
            talkAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[18]);
                examination3[3] = true;
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

        else if (collider.gameObject.CompareTag("EliPhoto2"))
        {
            talkAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

    }

    IEnumerator DoorOpened()
    {
        yield return new WaitForSeconds(3);
        FindObjectOfType<DialogueManager>().dialogueText.text = "";
    }
}
