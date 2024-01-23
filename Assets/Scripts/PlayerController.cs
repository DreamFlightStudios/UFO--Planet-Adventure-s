using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;
    [SerializeField] LayerMask _groundLayers;

    [Header("Camera Settings")]
    [SerializeField] private float _sensivity;
    [SerializeField] private Vector2Int _minMaxRotationX;

    [Header("Transforms")]
    [SerializeField] private Transform _cameraContainer;
    [SerializeField] private Transform _groundCheckPosition;

    [Header("�omponents")]
    [SerializeField] private Rigidbody _rigidbody;

    private PlayerInput _playerInput;

    private float _xRotation;
    private float _yRotation;

    private Vector3 _diraction;

    [Inject]
    private void Construct(PlayerInput playerInput) => _playerInput = playerInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() => RotateCamera();
    private void FixedUpdate() { if (IsGrounded()) Move(); }

    private void Move()
    {
        Vector2 input = _playerInput.Actions.MovementInput.ReadValue<Vector2>() * _speed;

        _diraction = input.x * transform.right + input.y * transform.forward;
        _rigidbody.velocity = new Vector3(_diraction.x, _rigidbody.velocity.y, _diraction.z);
    }

    private void RotateCamera()
    {
        Vector2 input = _playerInput.Actions.LookInput.ReadValue<Vector2>() * _sensivity * Time.fixedDeltaTime;

        _xRotation -= input.y;
        _yRotation += input.x;

        _xRotation = Mathf.Clamp(_xRotation, _minMaxRotationX.x, _minMaxRotationX.y);

        _cameraContainer.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded())
            _rigidbody.AddForce(_jumpForce * transform.up, ForceMode.Impulse);
    }

    private bool IsGrounded() => Physics.CheckSphere(_groundCheckPosition.position, 0.2f, _groundLayers);
    private void OnDisable() => _playerInput.Actions.Jump.performed -= Jump;
    private void OnEnable() => _playerInput.Actions.Jump.performed += Jump;
}
