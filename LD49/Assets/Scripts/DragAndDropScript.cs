using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (!GamestateScript.inGame)
        {
            offset = transform.position - mousePos;
        }
    }

    private void OnMouseDrag()
    {
        if (!GamestateScript.inGame)
        {
            transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, 0);
        }
    }
}
