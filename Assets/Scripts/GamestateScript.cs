using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamestateScript : MonoBehaviour
{
    public Button playButton;
    public static bool inGame;

    // Start is called before the first frame update
    void Start()
    {
        inGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to handle events when play button is pressed
    public void PressPlayButton()
    {
        GameObject.FindGameObjectWithTag("Graph").GetComponent<GraphComponent>().printEdges();
        Debug.Log("---------------");
        GameObject.FindGameObjectWithTag("Graph").GetComponent<GraphComponent>().CalculateWeights();
        playButton.interactable = false;
        inGame = true;
    }
}
