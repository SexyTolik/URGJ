using UnityEngine;

public class WeaphonController : MonoBehaviour
{
    private BulletManager bulmanager;
    public float ShootCoolDown = 3f;
    public float ProjectileSpeed = 15f;
    public Transform firePoint;
    private float TimeToNextShoot;
    private void Start()
    {
        bulmanager = BulletManager.Instance;
        TimeToNextShoot = Time.time;
    }

    public void MakeShoot(Vector3 target)
    {
        Rigidbody rb;
        if(Time.time > TimeToNextShoot)
        {
           rb = bulmanager.SpawnBullet(firePoint.position).GetComponent<Rigidbody>();
            Vector3 dir = new Vector3((target - firePoint.position).x, 0, (target - firePoint.position).z);
           rb.velocity = dir * ProjectileSpeed;
            TimeToNextShoot = Time.time+ShootCoolDown;
        }
    }
}