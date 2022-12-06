using UnityEngine;
using UnityEditor;

public class StageManager : MonoBehaviour
{
    //Like preloading in Godot?
    Object prefBall;

    GameObject canvas;
    GameObject ball;
    GameObject paddle;
    GameObject winScreen;
    GameObject loseScreen;
    GameObject attackMenu;

    private void Awake()
    {
        prefBall = AssetDatabase.LoadAssetAtPath("Assets/Ball/Ball.prefab", typeof(GameObject));

        paddle = GameObject.Find("Paddle");
        canvas = GameObject.Find("Canvas");
        winScreen = canvas.transform.Find("Win").gameObject;
        loseScreen = canvas.transform.Find("Lose").gameObject;
        attackMenu = canvas.transform.Find("AttackMenu").gameObject;
    }

    private void Start()
    {
        StageSetUp();
    }

    void StageSetUp()
    {
        winScreen.SetActive(false); //Messy, will change
        loseScreen.SetActive(false);
        attackMenu.SetActive(true);

    }

    public void AttackRoutine()
    {
        attackMenu.SetActive(false);
        SpawnBall();
    }

    public void ChooseRoutine()
    {
        attackMenu.SetActive(true);
    }

    public void SpawnBall()
    {
        this.ball = Instantiate(prefBall, paddle.transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
    }

    public void BallDeathRoutine()
    {
        ball.GetComponent<testBall>().KillBall();
        ChooseRoutine();
    }

    public void VictoryRoutine()
    {
        ball.GetComponent<testBall>().PauseBall();
        winScreen.SetActive(true);
    }

    public void DefeatRoutine()
    {
        loseScreen.SetActive(true);
    }
}
