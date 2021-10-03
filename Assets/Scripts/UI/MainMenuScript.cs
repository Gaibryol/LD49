using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            mainPanel.SetActive(true);
            levelPanel.SetActive(false);
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenLevelPanel()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void CloseLevelPanel()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void LoadLevel(int num)
    {
        SceneManager.LoadScene(num);
    }
}
