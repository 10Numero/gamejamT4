using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    public GameObject Preview;
    public GameObject Inv;
    public bool isSelected = false;
    public int index;


    private void Awake()
    {
        index = transform.GetSiblingIndex();
        index = transform.GetSiblingIndex();
        Preview = GameObject.FindGameObjectWithTag("Preview");
        Inv = GameObject.FindGameObjectWithTag("Inventory");

    }
    private void Update()
    {
        transform.SetSiblingIndex(index);
    }


    // Update is called once per frame

    public void SelectPic()
    {

        if (!isSelected)
        {
            Preview.SetActive(true);
            Preview.GetComponent<Preview>().OriginPic = this.gameObject;
            Preview.GetComponent<Preview>().BigPic.SetActive(true);
            //transform.parent = Preview.transform;
            //transform.localPosition = new Vector3(1f, 1f, 1f);
            //transform.localScale = new Vector3(160f, 100f, 1f);
            //else if (isSelected)
            //{
            //    Preview.GetComponent<Preview>().OriginPic = null;
            //    Preview.GetComponent<Preview>().BigPic.SetActive(false);
            //    Preview.SetActive(false);
            //    //transform.parent = Inv.transform;
            //    //transform.localScale = new Vector3(1f, 1f, 1f);
            //    isSelected = false; 
            //   transform.SetSiblingIndex(index);
        }
    }
}
