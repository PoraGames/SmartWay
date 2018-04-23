using UnityEngine;
using System.Collections;

public class GlobalData_SC : MonoBehaviour
{
    public static GlobalData_SC Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool isGamePaused = false;
}
