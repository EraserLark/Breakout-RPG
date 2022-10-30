using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBall : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject paddlePoint;

    float launchSpeed = 150f;
    bool startState = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        paddlePoint = GameObject.Find("Paddle").transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if(startState)
        { 
            if (Input.GetButtonDown("Jump")) //Spacebar
            {
                startState = false;
                paddlePoint.GetComponentInParent<testPaddle>().ChangePaddleColl(true);

                LaunchBall();
            }
        }

        print(rb.velocity);
    }

    private void FixedUpdate()
    {
        if(startState)
        {
            rb.MovePosition(paddlePoint.transform.position);
        }
    }

    void LaunchBall()
    {
        rb.AddForce(Vector2.up * launchSpeed);
    }
}
