using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBrick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        testBall ball = collision.gameObject.GetComponent<testBall>();
        if (ball != null)
        {
            Destroy(this.gameObject);
            print("Kaboom");
        }
    }
}
