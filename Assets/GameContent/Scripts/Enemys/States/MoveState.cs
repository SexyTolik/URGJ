using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : AbstractState
{
    public MoveState(BaseFSM fsm) : base(fsm) { }
    public override void EnterState()
    {
        Debug.Log("State entered");
    }

    public override void UpdateState()
    {
        Debug.Log("State updated");
    }

    public override void ExitState()
    {
        Debug.Log("State Exited");
    }
}
