using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDialog : MonoBehaviour
{
    [Header("User Interface")]
    public GameObject examineAid;
    public GameObject dialogueAid;
    public GameObject letterToRead;
    public GameObject newspaperToRead;
    public GameObject buttons;
    
    [Header("Audiosource")]
    public AudioSource audioS;
    
    [Header("William's Door")]
    public GameObject closedDoorWilliam;
    public GameObject opendedDoorWilliam;
    
    [Header("Objects from the Past to shot")]
    public GameObject pastBedRobert;
    public GameObject pastAlliance;
    public GameObject pastIntactBottle;
    public GameObject pastPokerTable;
    public GameObject pastVestRobert;
    public GameObject pastCarpet;
    public GameObject pastSuitcase;
    public GameObject pastBrokenLamp;
    public GameObject pastNewspaper;
    
    [Header("Dialogues")]
    public Dialogue[] commentsPresent;
    public Dialogue[] recaps;
    public Dialogue[] dialogues;
    public Dialogue openDoor;

    private bool lookAtBody = false;

    private bool[] examination1 = new bool[7];
    private bool[] examination2 = new bool[5];
    private bool[] examination3 = new bool[4];
    private bool[] examinationDialogues = new bool[4];

    private bool doOnceDoorNoise = false;
    private bool[] doOnceRecap = new bool[8];
    
    [Header("Conditions")]
    public bool firstCondition = false;
    public bool firstConditionPast = false;
    public bool secondCondition = false;
    public bool secondConditionPast = false;
    public bool finalCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        examineAid.SetActive(false);
        dialogueAid.SetActive(false);
        letterToRead.SetActive(false);
        buttons.SetActive(false);
        newspaperToRead.SetActive(false);
        closedDoorWilliam.SetActive(true);
        opendedDoorWilliam.SetActive(false);
        FindObjectOfType<DialogueManager>().dialogueText.text = "";

        pastBedRobert.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
        pastAlliance.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
        pastIntactBottle.GetComponent<ObjetOfInterest>().cantBePhotographed = false;

        firstCondition = false;
        firstConditionPast = false;
        secondCondition = false;
        secondConditionPast = false;
        finalCondition = false;

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

        for (int i = 0; i < examinationDialogues.Length; i++)
        {
            examinationDialogues[i] = false;
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
            pastBrokenLamp.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastPokerTable.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastVestRobert.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
            pastCarpet.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
        }

        if (pastBrokenLamp.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastPokerTable.GetComponent<ObjetOfInterest>().HasBeenPhotographed
            && pastVestRobert.GetComponent<ObjetOfInterest>().HasBeenPhotographed 
            && pastCarpet.GetComponent<ObjetOfInterest>().HasBeenPhotographed && firstConditionPast)
        {
            secondConditionPast = true;
        }

        if (secondConditionPast)
        {
            pastNewspaper.GetComponent<ObjetOfInterest>().cantBePhotographed = false;
        }

        if (secondCondition && secondConditionPast)
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
        if (examination2[2] && pastCarpet.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
        {
            if (!audioS.isPlaying && !doOnceRecap[3])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[3]);
                doOnceRecap[3] = true;
            }
        }

        // Recap 5
        if (examinationDialogues[0])
        {
            if (!audioS.isPlaying && !doOnceRecap[4])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[4]);
                doOnceRecap[4] = true;
            }
        }

        // Recap 6
        if (examinationDialogues[1])
        {
            if (!audioS.isPlaying && !doOnceRecap[5])
            {
                FindObjectOfType<DialogueManager>().StartDialogue(recaps[5]);
                doOnceRecap[5] = true;
            }
        }

        // Recap 7
        if (doOnceRecap[1] && secondCondition && secondConditionPast)
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

        if (examinationDialogues[0] && examinationDialogues[1] && examinationDialogues[2] && examinationDialogues[3])
        {
            finalCondition = true;
        }

        // Choose between Maria and William
        if (finalCondition && !audioS.isPlaying)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            buttons.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Body") && !lookAtBody && !audioS.isPlaying)
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
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[0]);
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[1]);
                examination1[0] = true;

            }

        }

        else if (collider.gameObject.CompareTag("Suitcase") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[2]);
                examination1[1] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Body") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[4]);
                examination1[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("BlueLips") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[5]);
                examination1[4] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Kit") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[6]);
                examination1[5] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Pills") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[7]);
                examination1[6] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Vomi") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[8]);
                examination1[3] = true;
            }

        }

        else if (collider.gameObject.CompareTag("LockedSuitcase") && secondCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[9]);
                examination3[0] = true;
            }

            if (pastNewspaper.GetComponent<ObjetOfInterest>().HasBeenPhotographed)
            {
                newspaperToRead.SetActive(true);
            }

        }

        else if (collider.gameObject.CompareTag("Letter") && secondCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

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

        else if (collider.gameObject.CompareTag("Tissue") && secondCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[11]);
                examination3[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("LampLessTable") && firstCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[12]);
                examination2[0] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Poker") && firstCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[13]);
                examination2[1] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Bar") && firstCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[14]);
                examination2[4] = true;
            }

        }

        else if (collider.gameObject.CompareTag("Rack") && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[15]);
            }

        }

        else if (collider.gameObject.CompareTag("Carpet") && firstCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[17]);
                examination2[2] = true;
            }

        }

        else if (collider.gameObject.CompareTag("EliPhoto2") && secondCondition && !audioS.isPlaying)
        {
            examineAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(commentsPresent[18]);
                examination3[3] = true;
            }

        }

        // Dialogue 1
        if(collider.gameObject.CompareTag("DoorDialogues") && doOnceRecap[1] && !audioS.isPlaying && !examinationDialogues[0] && !audioS.isPlaying)
        {
            dialogueAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogues[0]);
                examinationDialogues[0] = true;
            }
        }
        // Dialogue 2
        else if (collider.gameObject.CompareTag("DoorDialogues") && doOnceRecap[2] && examinationDialogues[0] && !examinationDialogues[1] && !audioS.isPlaying)
        {
            dialogueAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogues[1]);
                examinationDialogues[1] = true;
            }
        }
        // Dialogue 3
        else if (collider.gameObject.CompareTag("DoorDialogues") && doOnceRecap[7] && examinationDialogues[1] && !examinationDialogues[2] && !audioS.isPlaying)
        {
            dialogueAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogues[2]);
                examinationDialogues[2] = true;
            }
        }
        // Dialogue 4
        else if (collider.gameObject.CompareTag("DoorDialogues") && doOnceRecap[2] && !examinationDialogues[3] && !audioS.isPlaying)
        {
            dialogueAid.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogues[3]);
                examinationDialogues[3] = true;
            }
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClosedDoor"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("EliPhoto"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Suitcase"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Body"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("BlueLips"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Kit"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Pills"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Vomi"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LockedSuitcase"))
        {
            examineAid.SetActive(false);
            newspaperToRead.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Letter"))
        {
            examineAid.SetActive(false);
            letterToRead.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Tissue"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LampLessTable"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Poker"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Bar"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Rack"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("LunchTable"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("Carpet"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        else if (collider.gameObject.CompareTag("EliPhoto2"))
        {
            examineAid.SetActive(false);
            FindObjectOfType<DialogueManager>().dialogueText.text = "";
        }

        if (collider.gameObject.CompareTag("DoorDialogues"))
        {
            dialogueAid.SetActive(false);
        }

    }

    IEnumerator DoorOpened()
    {
        yield return new WaitForSeconds(4);
        FindObjectOfType<DialogueManager>().dialogueText.text = "";
    }
}
