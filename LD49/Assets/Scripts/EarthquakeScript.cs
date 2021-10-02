using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeScript : MonoBehaviour
{
    public float shakeTimer;
    private float timer;

    private bool shaking;

    // Start is called before the first frame update
    void Start()
    {
        shaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            StopShake();
        }

        if (shaking)
        {
            transform.position = new Vector2(transform.position.x + Random.Range(-0.05f, 0.05f), transform.position.y + Random.Range(-0.05f, 0.05f));
        }
    }

    public void StartShake()
    {
        timer = shakeTimer;
        shaking = true;
    }

    public void StopShake()
    {
        shaking = false;
    }
}
