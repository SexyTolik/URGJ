using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : AbstractState
{
    private Transform _PlayerTr;
    private Transform _EnemyTr;
    private BaseFSM _FSM;
    private WeaphonController _Weapon;
    public FightState(BaseFSM fsm, Transform player, Transform enemy, WeaphonController weaphon) : base(fsm)
    {
        _FSM = fsm;
        _PlayerTr = player;
        _EnemyTr = enemy;
        _Weapon = weaphon;
    }
    public override void EnterState()
    {
        Debug.Log("State entered");
    }

    public override void UpdateState()
    {
        if (checkPlayerInVision())
        {
            _EnemyTr.LookAt(_PlayerTr);
            _Weapon.MakeShoot(_PlayerTr.position);
        }
        
    }

    public override void ExitState()
    {
        Debug.Log("State Exited");
    }

    private bool checkPlayerInVision()
    {
        Vector3 direction = _PlayerTr.position - _EnemyTr.position;
        float distance = direction.magnitude;

        Debug.DrawLine(_EnemyTr.position, _PlayerTr.position, Color.yellow);

        // ������� ��� �� ���������� � ������
        if (Physics.Raycast(_EnemyTr.position, direction, out RaycastHit hit, distance, LayerMask.GetMask("Obstacle")))
        {
            // ���� ��� ���������� � ������������ �� ���������� ������
            if (hit.collider.CompareTag("Player") == false)
            {
                _FSM.SetState<IdleState>();
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            _FSM.SetState<IdleState>();
            return false;
        }
    }
}