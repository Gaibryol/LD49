using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelScript : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    public string nextStageName;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win(int num)
    {
        winPanel.SetActive(true);

        if (PlayerPrefs.GetInt((SceneManager.GetActiveScene().name + "Stars").ToLower()) <= num)
        {
            PlayerPrefs.SetInt((SceneManager.GetActiveScene().name + "Stars").ToLower(), num);
        }

        if (SceneManager.GetActiveScene().name.ToLower() != "mudroom")
        {
            PlayerPrefs.SetInt((nextStageName + "Unlock").ToLower(), 1);
        }
    }

    public void Lose()
    {
        losePanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
