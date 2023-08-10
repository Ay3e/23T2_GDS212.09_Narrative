using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockStatedCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    private void Update()
    {
            //Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
    }
}