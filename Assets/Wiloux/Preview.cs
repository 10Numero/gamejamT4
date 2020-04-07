using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public GameObject PreviewPic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PreviewPic != null) {
            PreviewPic = FindObjectOfType<Selected>().gameObject;
                }
    }
}
