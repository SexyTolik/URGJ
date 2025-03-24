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

    }

    public override void UpdateState()
    {
        if (checkPlayerInVision())
        {
            Quaternion rotation = _EnemyTr.rotation;
            rotation.SetLookRotation(_PlayerTr.position, Vector3.up);
            _EnemyTr.LookAt(_PlayerTr,Vector3.up);
            _Weapon.MakeShoot(_PlayerTr.position);
        }
        
    }

    public override void ExitState()
    {

    }

    private bool checkPlayerInVision()
    {
        Vector3 direction = _PlayerTr.position - _EnemyTr.position;
        float distance = direction.magnitude;

        Debug.DrawLine(_EnemyTr.position, _PlayerTr.position, Color.yellow);

        // ѕускаем луч от противника к игроку
        if (Physics.Raycast(_EnemyTr.position, direction, out RaycastHit hit, distance))
        {
            // ≈сли луч столкнулс€ с преп€тствием до достижени€ игрока
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