using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<AudioClip> voixOff;
    public GameObject GM;


    public AudioSource audio; //créer un gameobject avec le component audio source et glisse le ici

    // Use this for initialization
    void Start()
    {
        voixOff = new Queue<AudioClip>();
        sentences = new Queue<string>();
        GM = GameObject.FindGameObjectWithTag("GM");

    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        voixOff.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip theVoix in dialogue.voixOff)
        {
            voixOff.Enqueue(theVoix);
        }


        //PlayNextVoix();
        DisplayNextSentence();
    }

    /*public void StartVoix(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);

        //nameText.text = dialogue.name;

        voixOff.Clear();

        foreach (AudioClip theVoix in dialogue.voixOff)
        {
            voixOff.Enqueue(theVoix);
        }

        PlayNextVoix();
    }*/

    public void PlayNextVoix()
    {
        /*if (voixOff.Count == 0)
        {
            //FIN VOIX
            return;
        }*/

        Debug.Log("voix");
        AudioClip voix = voixOff.Dequeue();
        StopAllCoroutines();
        StartCoroutine(PlayVoixOff(voix));
    }

    public void DisplayNextSentence()
    {
        Debug.Log("sentence");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        AudioClip voix = voixOff.Dequeue();
        StartCoroutine(PlayVoixOff(voix));

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {

        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    IEnumerator PlayVoixOff(AudioClip voix)
    {
        audio.PlayOneShot(voix, 1);
        yield return null;
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
    }

}