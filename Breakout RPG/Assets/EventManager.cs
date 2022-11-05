using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    testBall ball;
    testPaddle paddle;
    BrickManager bm;
    GameObject winScreen;
    DeathField deathField;
    TurnManager turnManager;
    StageManager stageManager;

    private void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<testBall>();
        paddle = GameObject.Find("Paddle").GetComponent<testPaddle>();
        bm = GameObject.Find("BrickManager").GetComponent<BrickManager>();
        winScreen = GameObject.Find("Win").gameObject;
        deathField = GameObject.Find("DeathField").GetComponent<DeathField>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    private void Start()
    {
        deathField.ballIsDead += ball.KillBall;
        deathField.ballIsDead += stageManager.RespawnBall;
    }

    void PrintMessage()
    {
        print("Recieved Event");
    }
}
