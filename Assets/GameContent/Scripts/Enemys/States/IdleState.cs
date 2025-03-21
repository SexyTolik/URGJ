using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AbstractState
{
    private Transform PlayerTr;
    private Transform EnemyTr;
    private BaseFSM _FSM;
    public IdleState(BaseFSM fsm, Transform player, Transform enemy) : base(fsm)
    {
        _FSM = fsm;
        PlayerTr = player;
        EnemyTr = enemy;
    }
    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        checkPlayerInVision();
    }

    public override void ExitState()
    {

    }

    private void checkPlayerInVision()
    {
        Vector3 direction = PlayerTr.position - EnemyTr.position;
        float distance = direction.magnitude;

        // Пускаем луч от противника к игроку
        if (Physics.Raycast(EnemyTr.position, direction, out RaycastHit hit, distance))
        {
            // Если луч столкнулся с препятствием до достижения игрока
            if (hit.collider.CompareTag("Player") == false)
            {

            }
            else
            {

                _FSM.SetState<FightState>();
            }
        }
        else
        {

        }

        // Визуализация луча в редакторе
        Debug.DrawLine(EnemyTr.position, PlayerTr.position, Color.red);
    }
}