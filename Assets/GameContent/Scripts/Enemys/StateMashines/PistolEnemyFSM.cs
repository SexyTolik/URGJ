using GameContent.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemyFSM : MonoBehaviour
{
    private BaseFSM _FSM;
    public Transform PlayerTr;
    public Transform Enemy;
    public WeaphonController Gun;
    private bool IsDie = false;
    public GameObject DyingParticle;
    private void Start()
    {
        PlayerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = transform;
        _FSM = new BaseFSM();
        _FSM.AddState(new IdleState(_FSM, PlayerTr, Enemy));
        _FSM.AddState(new MoveState(_FSM));
        _FSM.AddState(new FightState(_FSM, PlayerTr, Enemy, Gun));
        _FSM.SetState<IdleState>();
    }
    void Update()
    {
        _FSM.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<Projectile>(out var bullet))
        {
            _FSM.AddState(new DyingState(_FSM, bullet.GetComponent<Rigidbody>().velocity * 30, GetComponent<Rigidbody>()));
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            _FSM.SetState<DyingState>();
            IsDie = true;
        }
        if(collision.collider.CompareTag("Wall") && IsDie)
        {
            Instantiate(DyingParticle, transform.position, Quaternion.LookRotation(PlayerTr.position));
            Destroy(gameObject);
        }
    }
}
