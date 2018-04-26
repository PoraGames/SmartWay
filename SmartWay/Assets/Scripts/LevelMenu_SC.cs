using UnityEngine;
using System.Collections;

public class LevelMenu_SC : MonoBehaviour
{
    public GameObject[] inGameInterfaceObjects;
    // public GameObject pauseMenu;
    public GameObject levelCompletedMenu;

    public void Pause()
    {
        GlobalData_SC.Instance.isGamePaused = true;
        foreach (GameObject _obj in inGameInterfaceObjects)
        {
            _obj.SetActive(false);
        }
    }

    public void Unpause()
    {
        GlobalData_SC.Instance.isGamePaused = false;
        foreach (GameObject _obj in inGameInterfaceObjects)
        {
            _obj.SetActive(true);
        }
    }

    public void LevelCompleted()
    {
        levelCompletedMenu.SetActive(true);
    }
}
