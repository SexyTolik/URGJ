using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemyFSM : MonoBehaviour
{
    private BaseFSM _FSM;

    private void Start()
    {
        _FSM = new BaseFSM();
        _FSM.AddState(new IdleState(_FSM));
        _FSM.AddState(new MoveState(_FSM));
        _FSM.AddState(new FightState(_FSM));
        _FSM.AddState(new DyingState(_FSM));
        _FSM.SetState<IdleState>();
    }
    void Update()
    {
        _FSM.Update();
    }
}
