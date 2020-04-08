using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 2.0f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float xAxisValueMouse = 0.0f;
    private float zAxisValueMouse = 0.0f;

    public bool Locked = false;     
    // Start is called before the first frame update
    void Start()
    {
        //START
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Locked)
        {
            Mouvement();
        }
    }

    private void Mouvement()
    {

        float xAxisValue = Input.GetAxis("Horizontal") * speed;
        float zAxisValue = Input.GetAxis("Vertical") * speed;
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            float horizontalOrient = Mathf.Sign(Input.GetAxis("Horizontal"));
            Vector3 horizontalDir = horizontalOrient * transform.right;
            horizontalDir.y = 0f;
            transform.position += horizontalDir * speed * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            float verticalOrient = Mathf.Sign(Input.GetAxis("Vertical"));
            Vector3 verticalDir = verticalOrient * transform.forward;
            verticalDir.y = 0f;
            transform.position += verticalDir * speed * Time.deltaTime;
        }

        xAxisValueMouse += speedH * Input.GetAxis("Mouse X");
        zAxisValueMouse -= speedV * Input.GetAxis("Mouse Y");
        
        zAxisValueMouse = Mathf.Clamp(zAxisValueMouse, -90f, 90f);

        transform.eulerAngles = new Vector3(zAxisValueMouse, xAxisValueMouse, 0.0f);

    }
}
