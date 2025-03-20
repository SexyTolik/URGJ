using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void FixedUpdate() // я попытался в одном фиксед апдейте чисто на условиях сделать анимацию туда и обратно. осталось парирование вставить и тестить
    {
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
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Projectile>(out var bullet)) 
        { 
            bullet.IsPaired = true;
        }
    }
}
