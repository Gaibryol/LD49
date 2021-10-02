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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(selected);
        if (selected)
        {
            foreach (GameObject obj in objects)
            {
                //obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        else if (!selected)
        {
            foreach (GameObject obj in objects)
            {
                //obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D obj = Physics2D.OverlapPoint(mousePos);

            if (obj)
            {
                selected = obj.transform.gameObject;
                offset = selected.transform.position - mousePos;
            }
            else
            {
                if (selected)
                {
                    selected = null;
                }
            }
        }

        if (Input.GetMouseButton(0) && selected)
        {
            selected.transform.position = mousePos + offset;
        }
    }
}
