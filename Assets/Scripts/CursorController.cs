using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    
    public Texture2D pickupTexture;
    public Texture2D defaultTexture;
    public Texture2D holdTexture;

    private bool isHover;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHover)
        {
            Cursor.SetCursor(holdTexture, Vector2.zero, CursorMode.Auto);
            FindObjectOfType<AudioManager>().Play("Lift");
        } else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(defaultTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    public void SetCursorSelect()
    {
        Cursor.SetCursor(pickupTexture, Vector2.zero, CursorMode.Auto);
        isHover = true;
    }

    public void SetCursorDeselect()
    {
        Cursor.SetCursor(defaultTexture, Vector2.zero, CursorMode.Auto);
        isHover = false;

    }
}
