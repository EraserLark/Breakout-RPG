using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine
{
    IState currentState;

    public void ChangeState(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        currentState.Execute();
    }
}

public class AttackState : IState
{
    MonoBehaviour owner;
    MonoBehaviour target;

    public AttackState(MonoBehaviour owner, MonoBehaviour target)
    {
        this.owner = owner;
        this.target = target;
    }

    public void Enter()
    {
        target.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void Execute()
    {
        target.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public void Exit()
    {
        //Change color again??
    }
}