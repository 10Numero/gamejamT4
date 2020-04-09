using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenu : MonoBehaviour
{

    public Slider theSliderMusic;
    public Slider theSliderSFX;
    public float sliderValue;
    public float sliderValueSFX;
    public Material theMat;
    private float save;
    public bool isChanging;
    public bool closer;
    public Color theColor;
    public GameObject parentLiquidBouteille;

    public bool theFirst;

    // Start is called before the first frame update
    void Start()
    {
        theColor.a = 1;
       // theMat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = theSliderMusic.value;
        sliderValueSFX = theSliderSFX.value;
        if (theFirst == false)
        {
            Vector3 theVector = transform.localScale;
            theVector.y = sliderValue;
            transform.localScale = theVector;
        }
        else
        {
            Vector3 theVector = transform.localScale;
            theVector.y = sliderValueSFX;
            transform.localScale = theVector;

           
        }

        Vector3 bouteilleVector = parentLiquidBouteille.transform.localScale;
        theMat.color = theColor;
        bouteilleVector.y = sliderValue + sliderValueSFX;
        parentLiquidBouteille.transform.localScale = bouteilleVector;
    }

    public void GlassControl(System.Single vol)
    {
        Debug.Log("is changing");
        theColor = theMat.color;
        theColor.a = .3f;
        theMat.color = theColor;
        //isChanging = true;
        if(closer == false)
        {
            closer = true;
            StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(.3f);
        //isChanging = false;
        theColor.a = 1;
        closer = false;
    }
}
