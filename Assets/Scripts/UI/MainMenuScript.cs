using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            mainPanel.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Level Select")
        {
            FindObjectOfType<AudioManager>().Play("Level Select");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenLevelPanel()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void LoadLevel(int num)
    {
        FindObjectOfType<AudioManager>().Play("Click");

        SceneManager.LoadScene(num);
    }
}
