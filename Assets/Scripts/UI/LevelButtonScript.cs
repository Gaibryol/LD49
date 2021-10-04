using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    public List<GameObject> stars;

    public GameObject head;

    public bool unlocked;

    public string stage;

    private void OnEnable()
    {
        // Determine number of stars and if unlocked
        ShowStars(PlayerPrefs.GetInt((stage + "Stars").ToLower()));

        if (PlayerPrefs.GetInt((stage + "Unlock").ToLower()) == 1)
        {
            unlocked = true;
        }
    }

    public void ShowStars(int num)
    {
        for (int i = 0; i < num; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void ShowHead()
    {
        if (unlocked)
        {
            head.SetActive(true);
        }
    }

    public void HideHead()
    {
        if (unlocked)
        {
            head.SetActive(false);
        }
    }

    public void LoadLevel(int num)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(num);
        }
    }
}
