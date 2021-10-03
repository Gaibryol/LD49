using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    CursorController cursor;
    public bool selectable = true;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CursorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (selectable)
        {
            cursor.SetCursorSelect();
        } else
        {
            cursor.SetCursorDeselect();
        }
    }

    private void OnMouseExit()
    {
        cursor.SetCursorDeselect();
    }
}
