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

    }

    public void SwitchSound()
    {
        soundButton.GetComponent<Image>().sprite = soundOff;
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
        musicButton.GetComponent<Image>().sprite = musicOff;
        PlayerPrefs.SetInt("Music", -1 * PlayerPrefs.GetInt("Music"));
        if (PlayerPrefs.GetInt("Music") == -1)
        {
            FindObjectOfType<AudioManager>().Mute("Level Select", true);
        } else
        {
            FindObjectOfType<AudioManager>().Mute("Level Select", false);

        }
    }
}
