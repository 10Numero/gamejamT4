using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTaker : MonoBehaviour
{
    public PastCamPic cam2;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            cam2.CallTakeSnap();
        }
    }
}
