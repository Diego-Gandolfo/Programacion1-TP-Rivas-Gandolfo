using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Manager : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    public bool fullScreen = true;
    public int refreshRate = 60;

    private void Start()
    {
        ChangeScreenSettings();
    }

    public void ChangeScreenSettings()
    {
        Screen.SetResolution(width, height, fullScreen, refreshRate);
    }
}
