using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelChanger_SC : MonoBehaviour
{
    public int currentLevelNumber = 0;
    public int maxLevelNumber = 3;

    public void LoadNewLevel(int newLevelNumber)
    {
        SceneManager.LoadScene(newLevelNumber + "_lvl");
    }

    public void LoadNewLevel(string newLevelName)
    {
        SceneManager.LoadScene(newLevelName);
    }

    public void ReloadLevel()
    {
        LoadNewLevel(currentLevelNumber);
    }

    public void LoadNextLevel()
    {
        if ((currentLevelNumber + 1) > maxLevelNumber)
        {
            LoadNewLevel("Levels");
        }
        else
        {
            LoadNewLevel(currentLevelNumber + 1);
        }
    }
}
