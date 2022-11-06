using UnityEngine;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    //Like preloading in Godot?
    Object prefBall;

    GameObject ball;
    GameObject paddle;

    private void Awake()
    {
        prefBall = AssetDatabase.LoadAssetAtPath("Assets/Ball/Ball.prefab", typeof(GameObject));

        ball = GameObject.Find("Ball");
        paddle = GameObject.Find("Paddle");
    }

    private void Start()
    {
        //SpawnBall();
    }

    public void BallDeathRoutine()
    {
        ball.GetComponent<testBall>().KillBall();
        SpawnBall();
    }

    public void SpawnBall()
    {
        this.ball = Instantiate(prefBall, paddle.transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;

        GameObject.Find("TurnManager").GetComponent<TurnManager>().ball = this.ball.GetComponent<testBall>();
    }
}
