using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public int interestState;
    //public Dialogue voix;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, interestState);
        //FindObjectOfType<DialogueManager>().StartDialogue(voix);
    }

}