using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuBehaviour : MonoBehaviour
{
    public float gForce = -9.8f;
    public float rotationSensitivity = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * (gForce * rotationSensitivity));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        //transform.Rotate(new Vector3(0, 0, 1), Input.GetAxis("Horizontal") * 2, Space.Self);
        //GetComponent<Rigidbody2D>().velocity = -transform.up * 4;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (gForce * rotationSensitivity));
    }
}
