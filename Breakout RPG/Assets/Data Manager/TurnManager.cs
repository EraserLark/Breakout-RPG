using UnityEngine;

public class TurnManager : MonoBehaviour
{
    StageManager stageManager;

    private void Awake()
    {
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
