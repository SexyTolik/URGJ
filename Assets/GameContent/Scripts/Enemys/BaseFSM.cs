using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseFSM
{
    private AbstractState CurrentState;
    [SerializeField]
    private Dictionary<Type, AbstractState> _states = new Dictionary<Type, AbstractState>();

    public void AddState(AbstractState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : AbstractState
    {
        var type = typeof(T);

        if(CurrentState?.GetType() == type)
        {
            return;
        }

        if (_states.TryGetValue(type, out var newState))
        {
            CurrentState?.ExitState();
            CurrentState = newState;
            CurrentState?.EnterState();
        }
    }
    public void Update()
    {
        CurrentState.UpdateState();
    }
}
