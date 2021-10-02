using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRoundingScript : MonoBehaviour
{
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbody.velocity.x > -0.001 && rbody.velocity.x < 0.001)
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }
        if (rbody.velocity.y > -0.001 && rbody.velocity.y < 0.001)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0);
        }

        if (rbody.angularVelocity > -0.001 && rbody.angularVelocity < 0.001)
        {
            rbody.angularVelocity = 0;
        }

        if (rbody.rotation > -0.01 && rbody.rotation < 0.01)
        {
            rbody.rotation = 0;
        }
    }
}
