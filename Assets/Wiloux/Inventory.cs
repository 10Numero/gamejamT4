using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public PastCamPic cam2;
    public GameObject Inv;
    public GameObject Preview;
    public GameObject Photo;
    public List<GameObject> PhotoList;
    public FPSController FpsControl;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenInv();
        }
    }

    public void OpenInv()
    {
        if (Inv.gameObject.activeInHierarchy)
        {
            FpsControl.Locked = false;
            Cursor.lockState = CursorLockMode.Locked;
            Preview.gameObject.SetActive(false);
            Inv.gameObject.SetActive(false);

        }
        else if (!Inv.gameObject.activeInHierarchy)
        {
            FpsControl.Locked = true;
            Cursor.lockState = CursorLockMode.None;
            Preview.SetActive(true);
            Inv.gameObject.SetActive(true);
            foreach (Texture2D Pic in cam2.ImageList)
            {
                GameObject Pho = Instantiate(Photo, Inv.transform);
                PhotoList.Add(Pho);
                Pho.transform.localScale = new Vector3(1, 1, 1);
                RawImage PhoImg = (RawImage)Pho.GetComponent(typeof(RawImage));
                PhoImg.texture = Pic;
            }
            cam2.ImageList.Clear();
        }
    }
}
