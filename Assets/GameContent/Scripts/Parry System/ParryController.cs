using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryController : MonoBehaviour
{
    public float ParryRadius = 1f;
    public float SuperParryRadius = 0.3f;

    public float ParryForce = 3f;

    public float ParryCooldown = 0.1f;
    private float TimeUntilCooldown;

    private void Start()
    {
        TimeUntilCooldown = Time.time;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<Projectile>(out var bullet) && (transform.position - other.transform.position).magnitude <= ParryRadius)
        {
            if(Input.GetAxis("Fire1") > 0 && !bullet.IsPaired && TimeUntilCooldown < Time.time)
            {
                //Parry(bullet.GetComponent<Rigidbody>(), (transform.position - other.transform.position).magnitude <= SuperParryRadius ? true : false);
                spawnHand(bullet.GetComponent<Rigidbody>());
                TimeUntilCooldown = Time.time+ParryCooldown;
            }
        }
    }

    private void spawnHand(Rigidbody bulletRb)
    {
        Hand hand = HandsPoolController.Instance.SpawnHand(getRandomPositionOfHand()).GetComponent<Hand>();
        hand.Target = bulletRb.transform;
        hand.ParryControllerTr = transform;
        hand.parryController = this;
        hand.MoveToTarg();
        /*hand.startPosition = hand.transform.position;
        hand.OffsetForStartPoint = hand.startPosition - transform.position;
        hand.parryController = this;
        hand.isMoving = true;*/
    }

    private Vector3 getRandomPositionOfHand()
    {
        float angle = Random.Range(0, 360); // Случайный угол от 0 до 360 градусов
        return GetEdgePoint(GetViewRadius(Camera.main),angle);
    }

    public Vector3 GetEdgePoint(float radius, float angleDegrees)
    {
        // Преобразуем угол в радианы
        float angleRad = angleDegrees * Mathf.Deg2Rad;

        // Вычисляем направление в локальных координатах объекта (плоскость XZ)
        Vector3 localDirection = new Vector3(
        Mathf.Cos(angleRad),  // X
        Mathf.Sin(angleRad),  // Y
        0                     // Z
        ) * radius;

        // Преобразуем локальное направление в мировые координаты
        Vector3 worldDirection = transform.TransformDirection(localDirection);

        // Возвращаем итоговую точку
        Debug.Log("Рука должна заспавнится в " + (transform.position + worldDirection));
        return transform.position + worldDirection;
    }

    public float GetViewRadius(Camera camera)
    {
        // Угол FOV в радианах (вертикальный)
        float fovRad = camera.fieldOfView * Mathf.Deg2Rad;

        // Высота и ширина области видимости на заданном расстоянии
        float height = 2f * 1 * Mathf.Tan(fovRad / 2f);
        float width = height * camera.aspect; // Учёт соотношения сторон

        // Диагональный радиус (половина диагонали прямоугольника)
        return Mathf.Sqrt((width / 2f) * (width / 2f) + (height / 2f) * (height / 2f));
    }
    public void Parry(Rigidbody rb) //, bool isSuperParry)
    {
        rb.velocity = -rb.velocity * ParryForce;//(isSuperParry ? ParryForce * 2 : ParryForce);
    }
}
