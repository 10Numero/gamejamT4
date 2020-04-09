using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventMenu : MonoBehaviour
{

    public Animator anim;
    public AudioSource audio;
    public AudioClip wood;
    private bool closer;

    public Text percentLoading;
    public Slider loadingSlider;

    public GameObject loadingScreen;

    public Animator animCam;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        if (closer == false){
            audio.PlayOneShot(wood, 1);
            closer = true;
        }

       
        anim.SetBool("over_", true);
    }

    void OnMouseExit()
    {
        anim.SetBool("over_", false);
        closer = false;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void EnterSettings()
    {
        animCam.SetBool("inSettings", true);
    }

    public void ExitSettings()
    {
        animCam.SetBool("inSettings", false);
    }

    public void Play()
    {
        animCam.SetTrigger("play");
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(LoadAsynchronously(1));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            percentLoading.text = progress * 100f + "%";
            yield return null;
        }
    }
}
