using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManipulationScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 offset;
    private GameObject selected;

    private GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Object");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamestateScript.inGame)
        {
            // Refresh object list
            objects = GameObject.FindGameObjectsWithTag("Object");

            // Get mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // If there is an object selected
            if (selected)
            {
                // Iterate through all interactable objects and make them static
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    //obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
            // If there isn't an object selected
            else if (!selected)
            {
                // Iterate through all interactable objects and make them dynamic
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    //obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                }
            }

            // Check if left click is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Find object that was clicked on
                Collider2D obj = Physics2D.OverlapPoint(mousePos);

                // If object was found
                if (obj && obj.GetComponent<Selectable>().selectable)
                {
                    // Make clicked on object selected and calculate offset
                    selected = obj.transform.gameObject;
                    offset = selected.transform.position - mousePos;
                }
                // If no object was found, deselect current object (if possible)
                else
                {
                    if (selected)
                    {
                        selected = null;
                    }
                }
            }

            // Move object with mouse position if it is selected and dragged
            if (Input.GetMouseButton(0) && selected)
            {
                selected.transform.position = mousePos + offset;
            }
        }
        
        // If in game, remove selection
        if (GamestateScript.inGame)
        {
            selected = null;
        }
    }
}
