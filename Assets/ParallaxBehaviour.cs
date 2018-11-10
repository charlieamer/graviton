using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    public float Strength = 0.2f;

    Vector3 StartPosition;
    Vector3? CameraStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.current)
        {
            if (CameraStartPosition == null)
            {
                CameraStartPosition = new Vector3(
                    Camera.current.transform.position.x,
                    Camera.current.transform.position.y,
                    Camera.current.transform.position.z);
            }
            else
            {
                transform.position = StartPosition + (Camera.current.transform.position - CameraStartPosition.Value) * Strength;
                transform.position.Set(transform.position.x, transform.position.y, 10000);
            }
        }
    }
}
