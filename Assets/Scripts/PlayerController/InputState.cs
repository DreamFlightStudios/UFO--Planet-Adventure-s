using UnityEngine;

public class InputState : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    private PlayerInput _playerInput;

    private void Awake() => _playerInput = new PlayerInput();
    private void Update() => ReadValue();
    private void ReadValue()
    {
        MovementInput = _playerInput.PlayerActions.MovementInput.ReadValue<Vector2>();
        LookInput = _playerInput.PlayerActions.LookInput.ReadValue<Vector2>();
    }
    private void OnEnable() => _playerInput.Enable();
    private void OnDisable() => _playerInput.Disable();
}
