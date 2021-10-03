using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Debug.Log(this.gameObject + " was hit by: " + collision.gameObject + " w/ " + KineticEnergy(collision) + "J");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Debug.Log(this.gameObject + " getting hit by: " + collision.gameObject + " w/ " + KineticEnergy(collision) + "J");
        }
    }

    private float KineticEnergy(Collision2D collision)
    {
        Rigidbody2D colRBody = collision.gameObject.GetComponent<Rigidbody2D>();
        return 0.5f * colRBody.mass * collision.relativeVelocity.sqrMagnitude;
    }
}
