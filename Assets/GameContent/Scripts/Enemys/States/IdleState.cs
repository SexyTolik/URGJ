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
        Debug.Log("State entered");
    }

    public override void UpdateState()
    {
        checkPlayerInVision();
    }

    public override void ExitState()
    {
        Debug.Log("State Exited");
    }

    private void checkPlayerInVision()
    {
        Vector3 direction = PlayerTr.position - EnemyTr.position;
        float distance = direction.magnitude;

        // ������� ��� �� ���������� � ������
        if (Physics.Raycast(EnemyTr.position, direction, out RaycastHit hit, distance))
        {
            // ���� ��� ���������� � ������������ �� ���������� ������
            if (hit.collider.CompareTag("Player") == false)
            {
                Debug.Log("����������� ����������: " + hit.collider.name);
            }
            else
            {
                Debug.Log("����� ���������");
                _FSM.SetState<FightState>();
            }
        }
        else
        {
            Debug.Log("������ �� ����������");
        }

        // ������������ ���� � ���������
        Debug.DrawLine(EnemyTr.position, PlayerTr.position, Color.red);
    }
}