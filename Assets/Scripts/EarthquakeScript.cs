using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeScript : MonoBehaviour
{
    public float shakeTimer;
    private float timer;

    private bool shaking;

    public float shakeFactorEasy;
    public float shakeFactorMedium;
    public float shakeFactorHard;

    public int numStars;

    private Rigidbody2D rbody;

    public EndPanelScript eScript;

    // Start is called before the first frame update
    void Start()
    {
        shaking = false;
        numStars = 0;

        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement timer if shaking
        if (timer >= 0 && shaking)
        {
            timer -= Time.deltaTime;
        }

        // Check if shaking and timer hits 0
        // If game hits this point, that means player beat hard and gets 3 stars
        if (timer < 0 && shaking)
        {
            numStars = 3;
            StopShake();
        }
    }

    private void FixedUpdate()
    {
        // If currrently shaking
        if (shaking)
        {
            // Timing for easy shaking
            if (timer > 12f && timer <= shakeTimer)
            {
                rbody.position = new Vector2(transform.position.x + Random.Range(-shakeFactorEasy, shakeFactorEasy), transform.position.y + Random.Range(-shakeFactorEasy, shakeFactorEasy));
            }
            // If hit this point, player earned 1 star and bump it up to medium
            else if (timer > 7f && timer <= 12f)
            {
                numStars = 1;
                rbody.position = new Vector2(transform.position.x + Random.Range(-shakeFactorMedium, shakeFactorMedium), transform.position.y + Random.Range(-shakeFactorMedium, shakeFactorMedium));
            }
            // Player hits 2 stars, bump it up to hard
            else
            {
                numStars = 2;
                rbody.position = new Vector2(transform.position.x + Random.Range(-shakeFactorHard, shakeFactorHard), transform.position.y + Random.Range(-shakeFactorHard, shakeFactorHard));
            }
        }
    }

    // Function to start shaking
    public void StartShake()
    {
        timer = shakeTimer;
        shaking = true;
        numStars = 0;
        FindObjectOfType<AudioManager>().Play("Earthquake");
    }

    // Function to stop shaking
    public void StopShake()
    {
        shaking = false;
        GamestateScript.inGame = false;

        eScript.ShowStars(numStars);
        FindObjectOfType<AudioManager>().Stop("Earthquake");
    }
}
