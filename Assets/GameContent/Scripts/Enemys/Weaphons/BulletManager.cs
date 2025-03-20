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
            createFunc: () => Instantiate(bulletPrefab), // Создание нового объекта
            actionOnGet: (bullet) => bullet.SetActive(true), // При получении из пула
            actionOnRelease: (bullet) => bullet.GetComponent<Projectile>().Deactivate(), // При возврате в пул
            actionOnDestroy: (bullet) => Destroy(bullet), // При уничтожении
            collectionCheck: true, // Проверка на повторное добавление
            defaultCapacity: 10, // Начальный размер
            maxSize: 1000 // Максимальный размер
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