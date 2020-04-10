using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public bool aze;
    public Transform[] tpPoint;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        if(aze == false)
        {
            player.transform.position = tpPoint[0].transform.position;
            aze = true;
        }
        else
        {
            player.transform.position = tpPoint[1].transform.position;
            aze = false;
        }
    }
}
