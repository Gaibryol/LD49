using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlHitScript : MonoBehaviour
{
    private EarthquakeScript eScript;

    // Start is called before the first frame update
    void Start()
    {
        eScript = GameObject.FindGameObjectWithTag("Ground").GetComponent<EarthquakeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GamestateScript.inGame)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            float kinEnergy = KineticEnergy(collision);

            if (kinEnergy >= 20f && GamestateScript.inGame)
            {
                Debug.Log("Hit by: " + collision.gameObject + " w/ " + kinEnergy + "J");
                FindObjectOfType<AudioManager>().Play("Hit");
                eScript.StopShake();
            }
        }
    }

    private float KineticEnergy(Collision2D collision)
    {
        Rigidbody2D colRBody = collision.gameObject.GetComponent<Rigidbody2D>();
        return 0.5f * colRBody.mass * collision.relativeVelocity.sqrMagnitude;
    }
}
