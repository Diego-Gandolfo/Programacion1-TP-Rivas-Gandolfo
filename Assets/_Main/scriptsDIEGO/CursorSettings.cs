using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    public bool cursorVisible = true;

    public void ChangeCursorSettings()
    {
        Cursor.visible = cursorVisible;
    }
}