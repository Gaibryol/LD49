using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{

    public GameObject soundButton;
    public GameObject musicButton;

    public Sprite soundOff;
    public Sprite musicOff;
    public Sprite soundOn;
    public Sprite musicOn;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetInt("SFX", 1);
        }
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SFX") == -1)
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOn;
        }

        if (PlayerPrefs.GetInt("Music") == -1)
        {
            musicButton.GetComponent<Image>().sprite = musicOff;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOn;
        }
    }

    public void SwitchSound()
    {
        PlayerPrefs.SetInt("SFX", -1 * PlayerPrefs.GetInt("SFX"));
        if (PlayerPrefs.GetInt("SFX") == -1)
        {
            FindObjectOfType<AudioManager>().Mute("Click", true);
        } else
        {
            FindObjectOfType<AudioManager>().Mute("Click", false);
        }
    }

    public void SwitchMusic()
    {
        PlayerPrefs.SetInt("Music", -1 * PlayerPrefs.GetInt("Music"));
        if (PlayerPrefs.GetInt("Music") == -1)
        {
            FindObjectOfType<AudioManager>().Mute("Menu", true);
        } else
        {
            FindObjectOfType<AudioManager>().Mute("Menu", false);

        }
    }
}
