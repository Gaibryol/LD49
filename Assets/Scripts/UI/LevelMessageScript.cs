using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMessageScript : MonoBehaviour
{
    public string text;
    public string hover;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover != "null")
        {
            if (hover == "music")
            {
                ChangeMessage("Toggle Music");
                return;
            }
            if (hover == "sound")
            {
                ChangeMessage("Toggle Sound Effects");
                return;
            }
            if (hover == "back")
            {
                ChangeMessage("Go back to main menu");
                return;
            }

            if (PlayerPrefs.GetInt(hover + "unlock") == 0)
            {
                ChangeMessage("I can't go there yet.");
            }
            else
            {
                ChangeMessage("Go go go!");
            }
        }
        else
        {
            ChangeMessage("Protect me from the earthquake!");
        }
    }

    public void ChangeMessage(string message)
    {
        GetComponent<TextMeshProUGUI>().text = message;
    }

    public void ChangeHover(string obj)
    {
        hover = obj.ToLower();
    }
}
