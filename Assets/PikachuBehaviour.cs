using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PikachuBehaviour : MonoBehaviour
{
    public float gForce = -9.8f;
    public float accelerationSensitivity = 5.0f;
    public float maxSpeed = 10.0f;
    public float acceleration = 1.5f;

    public Vector2 force;
    private Rigidbody2D character;
    private Vector2 prevForce;

    
    private float stamina = 5;
    public float maxStamina = 5;

    private int collected;
    private int collectables = 5;

    private GameObject finish;

    private Image staminaBarFull;
    private Image staminaBarLow;


    private Rect staminaRect;
    private Texture2D staminaTexture;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(force * (gForce));

        finish = GameObject.FindGameObjectWithTag("Finish");

        staminaBarFull = GameObject.Find("full").GetComponent<Image>();
        staminaBarLow = GameObject.Find("low").GetComponent<Image>();

        finish.SetActive(false);

        stamina = maxStamina;
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
            if (stamina > 0)
            {
                stamina -= 0.05f;
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

        // checking game finish update
        if (collected == collectables)
        {
            finish.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "portal-sprites_0")
        {
            Debug.Log("Game finished");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject, 0.1f);
            collected++;
        }
    }

    private void OnGUI()
    {
        float ratio = stamina / maxStamina;
        staminaBarFull.fillAmount = ratio;
        staminaBarLow.fillAmount = ratio;

        if (ratio < 0.3f)
        {
            staminaBarFull.enabled = false;
            staminaBarLow.enabled = true;
        }
        else
        {
            staminaBarFull.enabled = true;
            staminaBarLow.enabled = false;
        }
    }
}
