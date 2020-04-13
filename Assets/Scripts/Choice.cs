using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public Button button1;
    public Button button2;

    public bool button1Clicked = false;
    public bool button2Clicked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        button1.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {

    }
}
