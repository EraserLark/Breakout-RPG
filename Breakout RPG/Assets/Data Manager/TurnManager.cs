using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public testBall ball;
    testPaddle paddle;
    BrickManager bm;
    GameObject winScreen;

    private void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<testBall>();
        paddle = GameObject.Find("Paddle").GetComponent<testPaddle>();
        bm = GameObject.Find("BrickManager").GetComponent<BrickManager>();
        winScreen = GameObject.Find("Win").gameObject;
    }

    private void Start()
    {
        winScreen.SetActive(false); //Messy, will change
    }

    public void Victory()
    {
        ball.PauseBall();
        winScreen.SetActive(true);
    }
}
