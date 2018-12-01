using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SessionSingleton.Instance.GetSelectedCharacterPrefab(), transform.position, transform.rotation);
        Destroy(GetComponent<SpriteRenderer>());
    }
}
