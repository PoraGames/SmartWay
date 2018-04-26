using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelChanger_SC : MonoBehaviour
{
    public GameObject currentLevel;
    public GameObject[] allLevelPrefabs;
    public int currentLevelNumber = 0;

    public void LoadNewLevel(int newLevelNumber)
    {
        // Application.LoadLevel("1_lvl");
        SceneManager.LoadScene(newLevelNumber + "_lvl");
    }

    public void LoadNewLevel(string newLevelName)
    {
        // Application.LoadLevel("1_lvl");
        SceneManager.LoadScene(newLevelName);
    }

    public void ReloadLevel()
    {
        LoadNewLevel(currentLevelNumber);
    }
}
