using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Player;

    void Start()
    {
        if (GameObject.Find("pikachu"))
        {
            Player = GameObject.Find("pikachu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }
}
