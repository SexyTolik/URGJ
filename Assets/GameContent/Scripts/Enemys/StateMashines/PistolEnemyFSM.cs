using GameContent.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemyFSM : MonoBehaviour
{
    private BaseFSM _FSM;
    public Transform PlayerTr;
    public Transform Enemy;
    public WeaphonController Gun;
    private void Start()
    {
        PlayerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = transform;
        _FSM = new BaseFSM();
        _FSM.AddState(new IdleState(_FSM, PlayerTr, Enemy));
        _FSM.AddState(new MoveState(_FSM));
        _FSM.AddState(new FightState(_FSM, PlayerTr, Enemy, Gun));
        _FSM.AddState(new DyingState(_FSM));
        _FSM.SetState<IdleState>();
    }
    void Update()
    {
        _FSM.Update();
    }
}
