using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_LevelButton : MonoBehaviour
{
    private GameManager gameMan;

    private void Awake()
    {
        gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OpenLevel(int level)
    {
        gameMan.LoadLevel(level);
    }
}
