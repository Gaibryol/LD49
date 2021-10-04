using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamestateScript : MonoBehaviour
{
    public Button playButton;
    public static bool inGame;
    public Animator ClockAnim;

    // Start is called before the first frame update
    void Start()
    {
        inGame = false;
        ClockAnim = GameObject.FindGameObjectWithTag("Clock").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to handle events when play button is pressed
    public void PressPlayButton()
    {
        playButton.interactable = false;
        inGame = true;
        ClockAnim.SetBool("Clock Start", true);
    }
}
