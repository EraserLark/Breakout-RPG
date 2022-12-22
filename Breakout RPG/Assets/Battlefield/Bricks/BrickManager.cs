using UnityEngine;

public class BrickManager : MonoBehaviour
{
    TurnManager turnManager;
    int brickCount;

    private void Awake()
    {
        brickCount = gameObject.transform.childCount;
    }

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void BrickBroken()
    {
        brickCount--;

        if(brickCount <= 0)
        {
            turnManager.SwapTurnState("Victory");
        }
    }
}
