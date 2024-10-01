using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    public IState _previosState;

    private void Update()
    {
        if (CurrentState != null)
            CurrentState.Tick();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
            CurrentState.FixedTick();
    }

    public void ChangeState(IState newState)
    {
        if (CurrentState == newState)
            return;

        ChangeStateRoutine(newState);
    }

    void ChangeStateRoutine(IState newState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        if (_previosState != null)
            _previosState = CurrentState;

        CurrentState = newState;

        if (CurrentState != null)
        {
            CurrentState.Enter();
        }

    }
}
