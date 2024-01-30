using Player;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private PlayerController _playerController;

    public void ApplySettings() => Debug.Log("Save");

    public void ResetSettings() => Debug.Log("Load");

    public void SetVolume(float value) => _audioMixer.SetFloat("", value);

    public void SetSensivity(float value) => _playerController.Sensivity = value;

    public void SetDrawing(float value) => Camera.main.farClipPlane = value;

    private void OnDisable() => ResetSettings();

    private void OnEnable() => ResetSettings();
}
