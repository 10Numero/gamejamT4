using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public GameObject OriginPic;
    public GameObject BigPic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OriginPic != null)
        {
            BigPic.GetComponent<RawImage>().texture = OriginPic.GetComponent<RawImage>().texture;
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
        if (OriginPic.GetComponent<Selected>().index != 0)
        {
            OriginPic.GetComponent<Selected>().index--;
        }
    }
    public void AddIndex()
    {
        OriginPic.GetComponent<Selected>().index++;
    }
}
