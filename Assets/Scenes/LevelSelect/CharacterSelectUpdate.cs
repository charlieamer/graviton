using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectUpdate : MonoBehaviour
{
    void Start()
    {
        if (SessionSingleton.Instance.SelectedCharacter == GetComponentInChildren<UnityEngine.UI.Text>().text)
        {
            GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        }
    }
    public void OnValueChanged()
    {
        if (GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            SessionSingleton.Instance.SelectedCharacter = GetComponentInChildren<UnityEngine.UI.Text>().text;
        }
    }
}
