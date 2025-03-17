using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemyFSM : MonoBehaviour
{
    private BaseFSM _FSM;
    public Transform Player;
    public Transform Enemy;
    public WeaphonController Gun;
    private void Start()
    {
        Enemy = transform;
        _FSM = new BaseFSM();
        _FSM.AddState(new IdleState(_FSM, Player, Enemy));
        _FSM.AddState(new MoveState(_FSM));
        _FSM.AddState(new FightState(_FSM, Player, Enemy, Gun));
        _FSM.AddState(new DyingState(_FSM));
        _FSM.SetState<IdleState>();
    }
    void Update()
    {
        _FSM.Update();
    }
}
