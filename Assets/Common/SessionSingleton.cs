using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionSingleton
{
    #region SingletonSetup
    private static SessionSingleton _instance;
    public static SessionSingleton Instance {
        get {
            if (_instance == null)
            {
                _instance = new SessionSingleton();
            }
            return _instance;
        }
    }
    #endregion

    public string SelectedCharacter = "Pikachu";

    public GameObject GetSelectedCharacterPrefab()
    {
        return Resources.Load<GameObject>("Characters/" + SelectedCharacter);
    }
}
