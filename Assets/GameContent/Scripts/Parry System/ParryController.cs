using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryController : MonoBehaviour
{
    public float ParryRadius = 1f;
    public float SuperParryRadius = 0.3f;

    public float ParryForce = 3f;

    public delegate void ParryDelegate(Rigidbody rb); // бля я кажется не понял как делегатами пользоваться
    public ParryDelegate parryDelegate;
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<Projectile>(out var bullet) && (transform.position - other.transform.position).magnitude <= ParryRadius)
        {
            if(Input.GetAxis("Fire1") > 0)
            {
                //Parry(bullet.GetComponent<Rigidbody>(), (transform.position - other.transform.position).magnitude <= SuperParryRadius ? true : false);
                spawnHand(bullet.GetComponent<Rigidbody>());
            }
        }
    }

    private void spawnHand(Rigidbody bulletRb)
    {
        Hand hand = HandsPoolController.Instance.SpawnHand(transform.InverseTransformPoint(getRandomPositionOfHand())).GetComponent<Hand>();
        hand.Target = bulletRb.transform;
        hand.ParryControllerTr = transform;
        hand.startPosition = hand.transform.position;
        hand.OffsetForStartPoint = hand.startPosition - transform.position;
        hand.parryController = this;
        hand.isMoving = true;
    }

    private Vector3 getRandomPositionOfHand()
    {
        float angle = Random.Range(0f, 2 * Mathf.PI); // Случайный угол от 0 до 360 градусов
        Vector2 randomPoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return randomPoint;
    }
    public void Parry(Rigidbody rb) //, bool isSuperParry)
    {
        rb.velocity = -rb.velocity * ParryForce;//(isSuperParry ? ParryForce * 2 : ParryForce);
    }
}
