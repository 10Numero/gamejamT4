using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetOfInterest : MonoBehaviour
{
    public int GameState = 0;
    public int InterestState = 1;

    public Material InterestMat;
    public Material NonInterestMat;

    private Renderer rend;

    // Update is called once per frame

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        if(GameState == InterestState)
        {
            rend.material = InterestMat;
        }
        else
        {
            rend.material = NonInterestMat;
        }
    }
}
