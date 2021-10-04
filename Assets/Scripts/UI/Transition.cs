using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    CanvasGroup canvas;
    public float time = 2f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            canvas.alpha = 0;
            gameObject.SetActive(false);
            return;
        }
        canvas.alpha = timer / time;
        timer -= Time.deltaTime;
    }
}
