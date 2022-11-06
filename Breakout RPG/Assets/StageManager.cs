using UnityEngine;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    //Like preloading in Godot?
    Object prefBall;

    GameObject ball;
    GameObject paddle;
    GameObject winScreen;

    private void Awake()
    {
        prefBall = AssetDatabase.LoadAssetAtPath("Assets/Ball/Ball.prefab", typeof(GameObject));

        paddle = GameObject.Find("Paddle");
        winScreen = GameObject.Find("Win").gameObject;
    }

    private void Start()
    {
        StageSetUp();
    }

    void StageSetUp()
    {
        winScreen.SetActive(false); //Messy, will change
        SpawnBall();
    }

    public void SpawnBall()
    {
        this.ball = Instantiate(prefBall, paddle.transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
    }

    public void BallDeathRoutine()
    {
        ball.GetComponent<testBall>().KillBall();
        SpawnBall();
    }

    public void VictoryRoutine()
    {
        ball.GetComponent<testBall>().PauseBall();
        winScreen.SetActive(true);
    }
}
