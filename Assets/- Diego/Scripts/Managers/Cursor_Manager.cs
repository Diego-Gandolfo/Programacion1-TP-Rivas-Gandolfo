using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Manager : MonoBehaviour
{
    public bool cursorVisible = true;

    private void Start()
    {
        ChangeCursorSettings();
    }
    public void ChangeCursorSettings()
    {
        Cursor.visible = cursorVisible;
    }
}