using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanelScript : MonoBehaviour
{
    public GameObject panel;

    public List<GameObject> stars;

    public string stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStars(int num)
    {
        panel.SetActive(true);

        for (int i = 0; i < num; i++)
        {
            stars[i].SetActive(true);
        }

        if (num > PlayerPrefs.GetInt((stage + "Stars").ToLower()))
        {
            PlayerPrefs.SetInt((stage + "Stars").ToLower(), num);
        }

        if (num > 0)
        {
            PlayerPrefs.SetInt((stage + "Unlock").ToLower(), 1);
        }
    }
}
