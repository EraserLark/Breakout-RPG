using UnityEngine;

public class EventManager : MonoBehaviour
{
    public testBall ball;
    testPaddle paddle;
    BrickManager bm;
    GameObject winScreen;
    DeathField deathField;
    TurnManager turnManager;
    StageManager stageManager;
    BrickManager brickManager;

    private void Start()
    {
        winScreen = GameObject.Find("Win").gameObject;
        paddle = GameObject.Find("Paddle").GetComponent<testPaddle>();
        bm = GameObject.Find("BrickManager").GetComponent<BrickManager>();
        deathField = GameObject.Find("DeathField").GetComponent<DeathField>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        brickManager = GameObject.Find("BrickManager").GetComponent<BrickManager>();

        //Ball dies event
        deathField.ballIsDead += stageManager.BallDeathRoutine;

        //Bricks stop firing event
        stageManager.brickCeaseFire += brickManager.CeaseFire;
    }

    public void NewBall(testBall newBall)
    {
        ball = newBall;

        //Bricks start firing event
        ball.ballLaunched += brickManager.OpenFire;
    }

    void PrintMessage()
    {
        print("Recieved Event");
    }
}
