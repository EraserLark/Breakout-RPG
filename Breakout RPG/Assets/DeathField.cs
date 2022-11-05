using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    StageManager stageManager;
    
    public delegate void BallCollide();     //Delegate
    public event BallCollide ballIsDead;   //Event

    private void Awake()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        if(ball != null)
        {
            ballIsDead?.Invoke();   //If 'ballIsDead' is not null...
            //ball.KillBall();
            //stageManager.RespawnBall();
        }
    }
}
