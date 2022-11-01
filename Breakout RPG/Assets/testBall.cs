using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBall : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleColl;
    GameObject paddlePoint;

    testPaddle testPaddle;
    GameObject paddle;

    float launchSpeed = 10f;
    float maxVelocity;
    float sqrMaxVel;
    bool startState = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleColl = GetComponent<CircleCollider2D>();
        SetMaxVelocity(10f);    //Need to fine tune value

        paddlePoint = GameObject.Find("Paddle").transform.GetChild(0).gameObject;
        testPaddle = GameObject.Find("Paddle").GetComponent<testPaddle>();
        paddle = GameObject.Find("Paddle");
    }

    private void Start()
    {
        circleColl.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && startState) //Spacebar
        {
            startState = false;
            LaunchBall();
        }

        //print(rb.velocity);
    }

    private void FixedUpdate()
    {
        if(startState)
        {
            rb.MovePosition(paddlePoint.transform.position);
        }

        Vector2 v = rb.velocity;
        if(v.sqrMagnitude > sqrMaxVel)
        {
            rb.velocity = v.normalized * maxVelocity;
        }
    }

    void SetMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVel = maxVelocity * maxVelocity;
    }

    void LaunchBall()
    {
        float launchAngle = Random.Range(-50, 50);
        Quaternion rotation = Quaternion.AngleAxis(launchAngle, Vector3.forward);
        rb.velocity = rotation * Vector2.up * launchSpeed;

        circleColl.enabled = true;
    }
}
