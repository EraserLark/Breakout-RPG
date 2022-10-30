using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPaddle : MonoBehaviour
{
    float moveSpeed = 5f;

    private void Update()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        float speed = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(speed, 0, 0);
    }
}
