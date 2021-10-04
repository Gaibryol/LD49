using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarProgressScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("officestars"))
        {
            PlayerPrefs.SetInt("officestars", 0);
        }
        if (!PlayerPrefs.HasKey("bedroomstars"))
        {
            PlayerPrefs.SetInt("bedroomstars", 0);
        }
        if (!PlayerPrefs.HasKey("kitchenstars"))
        {
            PlayerPrefs.SetInt("kitchenstars", 0);
        }
        if (!PlayerPrefs.HasKey("livingroomstars"))
        {
            PlayerPrefs.SetInt("livingroomstars", 0);
        }
        if (!PlayerPrefs.HasKey("mudroomstars"))
        {
            PlayerPrefs.SetInt("mudroomstars", 0);
        }

        PlayerPrefs.SetInt("officeunlock", 1);
        if (!PlayerPrefs.HasKey("bedroomunlock"))
        {
            PlayerPrefs.SetInt("bedroomunlock", 0);
        }
        if (!PlayerPrefs.HasKey("kitchenunlock"))
        {
            PlayerPrefs.SetInt("kitchenunlock", 0);
        }
        if (!PlayerPrefs.HasKey("livingroomunlock"))
        {
            PlayerPrefs.SetInt("livingroomunlock", 0);
        }
        if (!PlayerPrefs.HasKey("mudroomunlock"))
        {
            PlayerPrefs.SetInt("mudroomunlock", 0);
        }
    }
}
