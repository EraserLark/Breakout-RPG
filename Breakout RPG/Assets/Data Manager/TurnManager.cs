using System.Collections;
using System.Collections.Generic;
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
}
