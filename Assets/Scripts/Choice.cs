using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public int idButton1 = 1;
    public int idButton2 = 2;

    public bool button1Clicked = false;
    public bool button2Clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        button1Clicked = false;
        button2Clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!button1Clicked && !button2Clicked)
        {
            button1.onClick.AddListener(() => ButtonClicked(1));
            button2.onClick.AddListener(() => ButtonClicked(2));
        }

        if (button1Clicked)
        {
            FindObjectOfType<EcranDeFin>().Defeat();
        }

        if (button2Clicked)
        {
            FindObjectOfType<EcranDeFin>().Victory();
        }

    }

    private void ButtonClicked(int idButton)
    {
        if(idButton == 1)
        {
            if (!button2Clicked)
            {
                button1Clicked = true;
            }
        }
        else if (idButton == 2)
        {
            if (!button1Clicked)
            {
                button2Clicked = true;
            }
        }
    }
}
