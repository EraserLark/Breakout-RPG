using UnityEngine;

public class TurnManager : MonoBehaviour
{
    GameManager gameMan;
    StageManager stageManager;

    private void Start()
    {
        gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    public void Victory()
    {
        stageManager.VictoryRoutine();
    }

    public void Defeat()
    {
        stageManager.DefeatRoutine();
    }

    public void Attack()
    {
        stageManager.AttackRoutine();
    }

    public void Run()
    {
        gameMan.LoadLevel("Overworld");
    }

    public void Choose()
    {
        stageManager.ChooseRoutine();
    }

    public void SwapTurnState(string newState)
    {
        switch (newState)
        {
            case "Victory":
                Victory();
                break;
            case "Defeat":
                Defeat();
                break;
            default:
                break;
        }
    }
}
