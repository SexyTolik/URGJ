using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BulletManager.Instance.ReturnBullet(gameObject);
    }

}
