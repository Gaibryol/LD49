using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    CanvasGroup canvas;
    public float time = 0.5f;
    float timer;
    private bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        timer = time;
        Invoke("StartFade", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fade)
        {
            return;
        }
        if (timer < 0)
        {
            canvas.alpha = 0;
            gameObject.SetActive(false);
            return;
        }
        canvas.alpha = timer / time;
        timer -= Time.deltaTime;
    }

    void StartFade()
    {
        fade = true;
    }
}
