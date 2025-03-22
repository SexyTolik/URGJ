using GameContent.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingState : AbstractState
{
    private BaseFSM _FSM;
    public Vector3 _DyingDirection;
    Rigidbody _Rb;
    public DyingState(BaseFSM fsm, Vector3 dyingDirection, Rigidbody rb) : base(fsm)
    {
        _FSM = fsm;
        _DyingDirection = dyingDirection;
        _Rb = rb;
    }
    public override void EnterState()
    {
        _Rb.AddForce((Vector3.up * (_DyingDirection.magnitude / 2)) + _DyingDirection, ForceMode.Acceleration);
        //_Rb.AddForce(_DyingDirection, ForceMode.Acceleration);
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {

    }
}