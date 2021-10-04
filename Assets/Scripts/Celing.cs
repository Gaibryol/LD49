using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Celing : MonoBehaviour
{
    Transform[] spawnPoints;
    

    public GameObject[] ceiling;
    bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = gameObject.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GamestateScript.inGame && !spawned)
        {
            System.Random random = new System.Random();

            List<Transform> shuffledList = new List<Transform>();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                do
                {
                    number = random.Next(0, spawnPoints.Length);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
                shuffledList.Add(spawnPoints[number]);
            }
            FindObjectOfType<AudioManager>().Play("Ceiling Break");
            int j = 0;
            foreach (Transform points in spawnPoints)
            {
                Instantiate(ceiling[j], points);
                j += 1;

            }
            spawned = true;
        }
    }
}
