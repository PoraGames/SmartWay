using UnityEngine;
using System.Collections;

public class SplashImage_SC : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
