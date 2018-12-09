using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private GameObject Player;
    private float gForce = 9.81f;
    public float PushForce = 200;
    private float XForce = 0;
    private float YForce = 0;
    private  bool SpringActive = false;

    void Start()
    {
        Player = GameObject.Find("Torso");
        XForce = -Mathf.Sin((transform.rotation.eulerAngles.z) * Mathf.PI / 180);
        YForce = Mathf.Cos((transform.rotation.eulerAngles.z) * Mathf.PI / 180);
        SpringActive = false;
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(!SpringActive)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(XForce * gForce * PushForce, YForce * gForce * PushForce));
            StartCoroutine("ReactivateSpring");
            SpringActive = true;
        }

    }

    IEnumerator ReactivateSpring()
    {
        yield return new WaitForSeconds(0.5f);
        SpringActive = false;
    }

    void Update()
    {
        
    }

}
