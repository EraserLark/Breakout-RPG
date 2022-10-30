using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBall : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump")) //Spacebar
        {
            LaunchBall();
        }

        print(rb.velocity);
    }

    void LaunchBall()
    {
        //rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(Vector2.up * 100);
    }
}
