using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{

    private GM theList;
    public Dialogue[] dialogue;
    public GameObject[] listeObjet;

    // Start is called before the first frame update
    void Start()
    {
        theList = FindObjectOfType<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTalkBot()
    {
        if (theList.PhotographedObjects.Contains(listeObjet[1]))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[1]);
        }
    }
}
