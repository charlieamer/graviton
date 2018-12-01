using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuBehaviour : MonoBehaviour
{
    public float gForce = -9.8f;
    public float accelerationSensitivity = 5.0f;
    public float maxSpeed = 10.0f;
    public float acceleration = 1.5f;
    public Vector2 force;
    private Rigidbody2D character;
    private Vector2 prevForce;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(force * (gForce));
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
        force = new Vector2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")) * accelerationSensitivity;
        if (Math.Abs(force.magnitude) < 0.00001f)
        {
            force = Vector2.up;
        }

        //force = Vector2.Lerp(prevForce, force, acceleration * Time.deltaTime);

        if (character.velocity.magnitude > maxSpeed)
        {
            character.velocity = character.velocity.normalized * maxSpeed;
        }

        character.AddForce(force * (gForce));
        prevForce = force;
    }
}
