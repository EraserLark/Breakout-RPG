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

    EventManager eventMan;
    public delegate void BrickStopFire();
    public event BrickStopFire brickCeaseFire;

    private void Awake()
    {
        prefBall = AssetDatabase.LoadAssetAtPath("Assets/Battlefield/Ball/Ball.prefab", typeof(GameObject));
    }

    private void Start()
    {
        paddle = GameObject.Find("Paddle");
        canvas = GameObject.Find("Canvas");
        winScreen = canvas.transform.Find("WinPanel").gameObject;
        loseScreen = canvas.transform.Find("Lose").gameObject;
        attackMenu = canvas.transform.Find("AttackMenu").gameObject;
        eventMan = GameObject.Find("EventManager").GetComponent<EventManager>();

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
        brickCeaseFire?.Invoke();   //event
    }

    public void SpawnBall()
    {
        this.ball = Instantiate(prefBall, paddle.transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
        eventMan.NewBall(this.ball.GetComponent<testBall>()); //Passes ball ref to the event manager (messy)
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
