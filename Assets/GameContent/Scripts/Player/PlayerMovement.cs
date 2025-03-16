using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _orientation;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _footSpot;
    [SerializeField] private GroundChecker _groundChecker;

    [Header("Movement Settings")]
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _dumping = 1f;
    [SerializeField] private float _gravityMultiplier = 3f;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 1f;

    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    private bool _canMove = true;
    private bool _canJump = true;

    private void Update()
    {
        if (_canMove == false) return;

        HandleInputs();
    }

    private void FixedUpdate()
    {
        Move();

        if (_groundChecker.Check() == false)
        {
            _rigidbody.velocity -= new Vector3(0f, 9.81f * _gravityMultiplier * Time.deltaTime, 0f);
        }
    }

    private void HandleInputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        Vector3 movement = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        _rigidbody.AddForce(movement * _acceleration * Time.deltaTime, ForceMode.Force);

        Vector3 dumpedVelocity = new Vector3(_rigidbody.velocity.x * _dumping, 0f, _rigidbody.velocity.z * _dumping);

        _rigidbody.velocity = new Vector3(dumpedVelocity.x, _rigidbody.velocity.y, dumpedVelocity.z);

        Vector3 clampMovement = Vector3.ClampMagnitude(new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z), _maxSpeed);

        _rigidbody.velocity = new Vector3(clampMovement.x, _rigidbody.velocity.y, clampMovement.z);
    }
    public void Jump()
    {
        if (_groundChecker.Check() == false) return;
        if (_canJump == false) return;

        Vector3 movement = _orientation.up * _jumpForce;

        _rigidbody.AddForce(movement, ForceMode.Impulse);
    }
}
