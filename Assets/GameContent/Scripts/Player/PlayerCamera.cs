using UnityEngine;

public class PlayerCamera : MonoComponent
{
    [Header("References")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _cameraSpot;
    [Header("Preferences")]
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private float _followSpeed = 1f;

    private float _rotationX;
    private float _rotationY;

    private void Awake()
    {
        LockCursor();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    private void Inputs()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivityY * Time.deltaTime;
        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
    }

    private void RotateCamera()
    {
        _camera.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        _orientation.rotation = Quaternion.Euler(0, _rotationY, 0);
    }

    private void MoveCamera()
    {
        _camera.transform.position = Vector3.Lerp(_camera.position, _cameraSpot.position, _followSpeed * Time.deltaTime);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetCameraTransform(Transform camera)
    {
        _camera = camera;
    }
}