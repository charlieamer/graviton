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

    private float stamina = 5, maxStamina = 5;

    private Rect staminaRect;
    private Texture2D staminaTexture;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(force * (gForce));

        staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.white);
        staminaTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
        }
        if (Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Vertical") == -1 || Input.GetAxis("Vertical") == 1)
        {
            Debug.Log("Stamina");
            if (stamina > 0)
            {
                stamina -= 0.1f;
            }
        }
        else
        {
            if (stamina < maxStamina)
            {
                stamina += 0.005f;
            }
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

        if (stamina > 0.5)
        {
            character.AddForce(force * (gForce));
        }
        prevForce = force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "portal-sprites_0")
        {
            Debug.Log("Here");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Debug.Log("Pick Up");
            Destroy(other.gameObject, 0.1f);
        }
    }

    private void OnGUI()
    {
        float ration = stamina / maxStamina;
        float rectWidth = ration * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture); 
    }
}
