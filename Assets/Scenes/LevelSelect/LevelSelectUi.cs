using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUi : MonoBehaviour
{
    public void LevelSelected(int LevelNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level" + LevelNum);
    }
}
