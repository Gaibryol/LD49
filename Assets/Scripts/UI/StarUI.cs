using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{

    EarthquakeScript earthquake;
    public int starNumber;
    private GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        earthquake = GameObject.FindGameObjectWithTag("Ground").GetComponent<EarthquakeScript>();
        star = this.transform.GetChild(0).gameObject;
        star.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (earthquake.numStars == starNumber)
        {
            star.SetActive(true);
        }
    }
}
