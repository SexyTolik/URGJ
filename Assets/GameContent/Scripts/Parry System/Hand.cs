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
    private void FixedUpdate() // я попытался в одном фиксед апдейте чисто на условиях сделать анимацию туда и обратно. осталось парирование вставить и тестить
    {
        /*
        if (!isMoving) return;
        transform.LookAt(Target);
        elapsedTime += Time.fixedDeltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration); // Ограничиваем t до 0-1

        transform.position = Vector3.Lerp(startPosition, isFinished ? Target.position + OffsetForStartPoint : Target.position, t);

        if (t >= 1f)
        {
            transform.position = Target.position; // Фиксируем конечную позицию
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
        Debug.Log("рука заспавнилась в " + transform.position);
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
