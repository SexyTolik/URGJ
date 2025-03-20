using UnityEngine;
using UnityEngine.Pool;

public class HandsPoolController : MonoBehaviour
{
    public static HandsPoolController Instance;

    public GameObject HandsPrefab;
    private ObjectPool<GameObject> handsPool;

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
        handsPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(HandsPrefab), // Создание нового объекта
            actionOnGet: (hand) => hand.SetActive(true), // При получении из пула
            actionOnRelease: (hand) => hand.SetActive(false), // При возврате в пул
            actionOnDestroy: (hand) => Destroy(hand), // При уничтожении
            collectionCheck: true, // Проверка на повторное добавление
            defaultCapacity: 10, // Начальный размер
            maxSize: 100 // Максимальный размер
        );
    }

    public GameObject SpawnHand(Vector3 position)
    {
        GameObject hand = handsPool.Get();
        hand.transform.position = position;
        return hand;
    }

    public void ReturnHand(GameObject hand)
    {
        handsPool.Release(hand);
    }
}
