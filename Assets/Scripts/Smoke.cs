using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kill", 1f);
    }

    // Update is called once per frame
    void Kill()
    {
        Destroy(this.gameObject);
    }
}
