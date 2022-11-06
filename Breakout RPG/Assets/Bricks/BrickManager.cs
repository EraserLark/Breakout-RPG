using UnityEngine;

public class BrickManager : MonoBehaviour
{
    TurnManager turnManager;
    int brickCount;

    private void Awake()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        brickCount = gameObject.transform.childCount;
    }

    public void BrickBroken()
    {
        brickCount--;

        if(brickCount <= 0)
        {
            turnManager.Victory();
        }
    }
}
