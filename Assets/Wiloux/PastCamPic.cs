using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PastCamPic : MonoBehaviour
{
    public Camera cam2;
    int resWidth = 1920;
    int resHeight = 1080;
    private Texture2D myGUITexture;
    public RawImage img;
    public List<Texture2D> ImageList;
    public GameObject PhotoCamPreview;
    public Animator anim;
    void Awake()
    {
        cam2 = gameObject.GetComponent<Camera>();
        if(cam2.targetTexture == null)
        {
            cam2.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = cam2.targetTexture.width;
            resHeight = cam2.targetTexture.height;
        }

    }


    private void LateUpdate()
    {
        if (cam2.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            cam2.Render();
            RenderTexture.active = cam2.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            //byte[] bytes = snapshot.EncodeToPNG();
            //string fileName = PictureName();
            //System.IO.File.WriteAllBytes(fileName, bytes);
            //cam2.gameObject.SetActive(false);
            //myGUITexture =(Texture2D) Resources.Load("pic" + PicNb + ".png");
            snapshot.Apply();
            PhotoCamPreview.GetComponent<RawImage>().texture = snapshot;
            ImageList.Add(snapshot);
         //   img.texture = snapshot;
            Debug.Log("PicTaken!");
            cam2.gameObject.SetActive(false); 
        }
    }
 
    public void CallTakeSnap()
    {
        cam2.gameObject.SetActive(true);
    }


}
