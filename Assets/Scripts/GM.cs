using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int GameState = 0;
    
    public List<GameObject> PhotographedObjects;
    public List<GameObject> lol;
    private DialogueManager DM;
    private BotScript BS;

    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        BS = FindObjectOfType<BotScript>().GetComponent<BotScript>();
    }

    private void Update()
    {
     
    }
}

