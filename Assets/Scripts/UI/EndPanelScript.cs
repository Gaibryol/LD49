using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelScript : MonoBehaviour
{
    public GameObject panel;

    public List<GameObject> stars;

    public string stage;

    public float endTime;
    private float timer;

    private bool ended;

    private float fadeTime;
    private float fadeTimer;

    public MainMenuScript mScript;

    // Start is called before the first frame update
    void Start()
    {
        ended = false;
        fadeTime = 2f;
        fadeTimer = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0 && ended)
        {
            SceneManager.LoadScene(1);
        }

        if (ended)
        {
            if (fadeTimer < 0)
            {
                panel.GetComponent<CanvasGroup>().alpha = 1;
                return;
            }
            panel.GetComponent<CanvasGroup>().alpha = 1 - (fadeTimer / fadeTime);
            fadeTimer -= Time.deltaTime;
        }
    }

    public void ShowStars(int num)
    {
        panel.SetActive(true);
        ended = true;

        for (int i = 0; i < num; i++)
        {
            stars[i].SetActive(true);
        }

        if (num > PlayerPrefs.GetInt((SceneManager.GetActiveScene().name + "Stars").ToLower()))
        {
            PlayerPrefs.SetInt((SceneManager.GetActiveScene().name + "Stars").ToLower(), num);
        }

        if (num > 0)
        {
            PlayerPrefs.SetInt((stage + "Unlock").ToLower(), 1);
        }

        timer = endTime;
    }
}
