using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleMouseCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
