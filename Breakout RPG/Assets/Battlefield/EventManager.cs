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

    private void Start()
    {
        winScreen = GameObject.Find("Win").gameObject;
        paddle = GameObject.Find("Paddle").GetComponent<testPaddle>();
        bm = GameObject.Find("BrickManager").GetComponent<BrickManager>();
        deathField = GameObject.Find("DeathField").GetComponent<DeathField>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();

        deathField.ballIsDead += stageManager.BallDeathRoutine;
    }

    void PrintMessage()
    {
        print("Recieved Event");
    }
}
