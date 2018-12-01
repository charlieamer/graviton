using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{

    private Rigidbody2D character;

    private void Start()
    {
        character = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        character.AddForce(Vector2.left * 9.8f);
    }
}
