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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchSound()
    {
        soundButton.GetComponent<Image>().sprite = soundOff;
    }

    public void SwitchMusic()
    {
        musicButton.GetComponent<Image>().sprite = musicOff;
    }
}
