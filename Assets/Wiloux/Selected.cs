using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    public GameObject Preview;
    public GameObject Inv;
    private bool isSelected = false;
    private int index;


    private void Awake()
    {
        index = transform.GetSiblingIndex();
        Preview = GameObject.FindGameObjectWithTag("Preview");
        Inv = GameObject.FindGameObjectWithTag("Inventory");

    }
    void Start()
    {
        Preview.GetComponentInChildren<Image>().enabled = false;
    }

    // Update is called once per frame

    public void SelectPic()
    {

        if (!isSelected)
        {
            Preview.SetActive(true);
            Preview.GetComponentInChildren<Image>().enabled = true;
            transform.parent = Preview.transform;
            transform.localPosition = new Vector3(1f, 1f, 1f);
            transform.localScale = new Vector3(160f, 100f, 1f);
            isSelected = true;
        }
        else if (isSelected)
        {
            Preview.GetComponentInChildren<Image>().enabled = false;
            Preview.SetActive(false);
            transform.parent = Inv.transform;
            transform.localScale = new Vector3(1f, 1f, 1f);
            isSelected = false; transform.SetSiblingIndex(index);
        }
    }
}
