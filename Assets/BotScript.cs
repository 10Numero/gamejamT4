using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BotScript : MonoBehaviour
{

    private GM theList;
    public Dialogue[] dialogue;
    public GameObject[] listeObjet;
    private bool[] closers;

    // Start is called before the first frame update
    void Start()
    {
        closers = new bool[17];
        theList = FindObjectOfType<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTalkBot()
    {
        if (theList.PhotographedObjects.Contains(listeObjet[1]) && closers[1] == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
            closers[1] = true;
        }

        else if (theList.PhotographedObjects.Contains(listeObjet[2]) && closers[2] == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[2]);
            closers[2] = true;
        }

        else if (theList.PhotographedObjects.Contains(listeObjet[3]) && closers[3] == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[3]);
            closers[3] = true;
        }


        // DERNIER ELSE IF = PLUS DE DIALOGUE DONC FEEDBACK AU PLAYER POUR DIRE IL NOUS FAUT PLUS D'INDICES OU QLQCHOSE DU GENRE
    }
}
