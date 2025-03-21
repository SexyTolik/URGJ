using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool IsPaired = false;
    private void OnCollisionEnter(Collision collision)
    {
        BulletManager.Instance.ReturnBullet(gameObject);
    }

    public void Deactivate()
    {
        IsPaired = false;
        gameObject.SetActive(false);
    }

}
