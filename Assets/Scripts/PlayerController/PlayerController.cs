using UnityEngine;
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

    [Header("Ñomponents")]
    [SerializeField] private InputState _inputState;
    [SerializeField] private Rigidbody _rigidbody;

    private float _xRotation;
    private float _yRotation;

    private Vector3 _movementDiraction;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector2 _movementInput = _inputState.MovementInput * _speed;
        Vector2 _lookInput = _inputState.LookInput * _sensivity * Time.deltaTime;

        RotateCamera(_lookInput);   
        if(IsGrounded()) Move(_movementInput);
    }
    private void Move(Vector2 input)
    {
        _movementDiraction = input.x * transform.right + input.y * transform.forward;
        _rigidbody.velocity = new Vector3(_movementDiraction.x, _rigidbody.velocity.y, _movementDiraction.z);
    }
    private void RotateCamera(Vector2 input)
    {
        _xRotation -= input.y;
        _yRotation += input.x;

        _xRotation = Mathf.Clamp(_xRotation, _minMaxRotationX.x, _minMaxRotationX.y);

        _cameraContainer.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded() && context.started) 
            _rigidbody.AddForce(_jumpForce * transform.up, ForceMode.Impulse);
    }
    private bool IsGrounded() => Physics.CheckSphere(_groundCheckPosition.position, 0.2f, _groundLayers);
}
