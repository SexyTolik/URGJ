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
            createFunc: () => Instantiate(HandsPrefab), // �������� ������ �������
            actionOnGet: (hand) => hand.SetActive(true), // ��� ��������� �� ����
            actionOnRelease: (hand) => hand.SetActive(false), // ��� �������� � ���
            actionOnDestroy: (hand) => Destroy(hand), // ��� �����������
            collectionCheck: true, // �������� �� ��������� ����������
            defaultCapacity: 10, // ��������� ������
            maxSize: 100 // ������������ ������
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
