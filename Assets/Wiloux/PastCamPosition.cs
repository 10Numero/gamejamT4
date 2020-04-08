using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastCamPosition : MonoBehaviour
{
public GameObject PresentCam;
public GameObject PastCam;
    public float OffSetX = 0;
    public float OffSetY = 0;
    public float OffSetZ = 0;

    private void Start()
    {
        PastCam.SetActive(false);
    }
    void Update()
    {
        transform.rotation = PresentCam.transform.rotation;
        transform.position = new Vector3((PresentCam.transform.position.x + OffSetX), (PresentCam.transform.position.y + OffSetY), (PresentCam.transform.position.z + OffSetZ));
    }
}
