using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{
    StageManager stageManager;

    private void Awake()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        if(ball != null)
        {
            ball.KillBall();
            stageManager.RespawnBall();
        }
    }
}
