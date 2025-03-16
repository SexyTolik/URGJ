using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Player player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        Camera camera = Instantiate(_camera, Vector3.zero, Quaternion.identity);

        player.ResolveComponent<PlayerCamera>().SetCameraTransform(camera.transform);
    }
}
