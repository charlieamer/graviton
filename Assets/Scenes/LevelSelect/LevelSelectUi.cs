using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUi : MonoBehaviour
{
    void LevelSelected(int LevelNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level" + LevelNum);
    }

    public void Level1Selected()
    {
        LevelSelected(1);
    }

    public void Level2Selected()
    {
        LevelSelected(2);
    }

    public void Level3Selected()
    {
        LevelSelected(3);
    }
}
