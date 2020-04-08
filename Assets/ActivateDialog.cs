using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialog : MonoBehaviour
{

    public bool setActivation = false;

    public GameObject talkAid;

    // Start is called before the first frame update
    void Start()
    {
        talkAid.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (setActivation)
        {
            talkAid.SetActive(true);

            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("Start Dialog"); // activer le système de dialogue ici
            }

        }
        else
        {
            talkAid.SetActive(false);
            // et désactiver ici
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("CPU"))
        {
            setActivation = true;

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("CPU"))
        {
            setActivation = false;
        }
    }
}
