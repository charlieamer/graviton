using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnQuitButtonClicked() {
        Debug.Log("Quit clicked");
        Application.Quit();
    }

    public void OnLevelSelectButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelSelect");
    }
}
