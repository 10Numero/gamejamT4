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

    public float yPosition = 3f;
        
    // Start is called before the first frame update
    void Start()
    {
        //START
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var altitude = transform.position;
        altitude.y = Mathf.Clamp(transform.position.y, yPosition, 3);
        transform.position = altitude;

        Mouvement();

    }

    private void Mouvement()
    {

        float xAxisValue = Input.GetAxis("Horizontal") * speed;
        float zAxisValue = Input.GetAxis("Vertical") * speed;
        
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += this.transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= this.transform.forward * speed * Time.deltaTime;

        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= this.transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += this.transform.right * speed * Time.deltaTime;

        }

        xAxisValueMouse += speedH * Input.GetAxis("Mouse X");
        zAxisValueMouse -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(zAxisValueMouse, xAxisValueMouse, 0.0f);

    }
}
