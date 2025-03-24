using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hand : MonoBehaviour
{
    public Transform Target;
    public Transform ParryControllerTr;
    public Vector3 OffsetForStartPoint;
    public float duration = 0.2f;

    public Vector3 startPosition;
    private float elapsedTime = 0f;
    public bool isMoving = false;
    private bool isFinished = false;

    public ParryController parryController;
    Tween curAnim;
    private void FixedUpdate() // � ��������� � ����� ������ ������� ����� �� �������� ������� �������� ���� � �������. �������� ����������� �������� � �������
    {
        /*
        if (!isMoving) return;
        transform.LookAt(Target);
        elapsedTime += Time.fixedDeltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration); // ������������ t �� 0-1

        transform.position = Vector3.Lerp(startPosition, isFinished ? Target.position + OffsetForStartPoint : Target.position, t);

        if (t >= 1f)
        {
            transform.position = Target.position; // ��������� �������� �������
            if (isFinished)
            {
                isMoving = false;
                isFinished = false;
                HandsPoolController.Instance.ReturnHand(gameObject);
            }
            else
            {
                parryController.Parry(Target.GetComponent<Rigidbody>());
                startPosition = Target.position;
                Target = ParryControllerTr;
                elapsedTime = 0f;
                isFinished = true;
            }
            
        } */
    }

    private void Update()
    {
        transform.rotation.SetLookRotation(Target.position,Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Projectile>(out var bullet)) 
        { 
            
        }
        
    }

    public void MoveToTarg()
    {
        Debug.Log("���� ������������ � " + transform.position);
        curAnim = transform.DOPunchPosition(Target.position - transform.position, 0.2f,1);//.SetLoops(1,LoopType.Yoyo);
        Target.GetComponent<Projectile>().IsPaired = true;
        parryController.Parry(Target.GetComponent<Rigidbody>());
        StartCoroutine(KillHand());
    }

    IEnumerator KillHand()
    {
        yield return curAnim.WaitForCompletion();
        HandsPoolController.Instance.ReturnHand(gameObject);
    }
}
