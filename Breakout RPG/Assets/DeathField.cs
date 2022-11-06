using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathField : MonoBehaviour
{  
    public delegate void BallCollide();     //Delegate
    public event BallCollide ballIsDead;   //Event

    private void OnTriggerEnter2D(Collider2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        if(ball != null)
        {
            ballIsDead?.Invoke();   //If 'ballIsDead' is not null...
        }
    }
}
