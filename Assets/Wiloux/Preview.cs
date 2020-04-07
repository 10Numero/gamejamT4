using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public GameObject OriginPic;
    public GameObject OriginPic0;
    public GameObject OriginPic2;
    public GameObject BigPic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OriginPic != null)
        {
            BigPic.GetComponent<RawImage>().texture = OriginPic.GetComponent<RawImage>().texture;
            int index1 = OriginPic.transform.GetSiblingIndex() - 1;
            int index2 = OriginPic.transform.GetSiblingIndex() + 1;

            if (index1 >= 0)
            {
                OriginPic0 = OriginPic.transform.parent.GetChild(OriginPic.transform.GetSiblingIndex() - 1).gameObject;
            }
            else
            {
                OriginPic0 = null;
            }

            if (index2 < OriginPic.transform.parent.childCount)
            {
                OriginPic2 = OriginPic.transform.parent.GetChild(OriginPic.transform.GetSiblingIndex() + 1).gameObject;
            }
            else
            {
                OriginPic2 = null;
            }
        }
        else
        {
            BigPic.GetComponent<RawImage>().texture = null;
        }
    }

    public void Delete()
    {

        OriginPic.GetComponent<Selected>().isSelected = false;
        Destroy(OriginPic);
    }

    public void RemoveIndex()
    {
        if (OriginPic0 != null)
        {
            OriginPic.GetComponent<Selected>().index--;
            OriginPic0.GetComponent<Selected>().index++;
        }
    }
    public void AddIndex()
    {
        if (OriginPic2 != null)
        {
            OriginPic.GetComponent<Selected>().index++;
            OriginPic2.GetComponent<Selected>().index--;
        }
    }
}
