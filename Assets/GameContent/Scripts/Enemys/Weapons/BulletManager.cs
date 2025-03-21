using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    public GameObject bulletPrefab;
    private ObjectPool<GameObject> bulletPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(bulletPrefab), 
            actionOnGet: (bullet) => bullet.SetActive(true), 
            actionOnRelease: (bullet) => bullet.GetComponent<Projectile>().Deactivate(),
            actionOnDestroy: (bullet) => Destroy(bullet), 
            collectionCheck: true, 
            defaultCapacity: 10,
            maxSize: 1000 
        );
    }

    public GameObject SpawnBullet(Vector3 position)
    {
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = position;
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
    }
}