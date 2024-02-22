using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Camera _camera;

    public void ApplySettings() => Debug.Log("Save");

    public void ResetSettings() => Debug.Log("Load");

    public void SetVolume(float value) => _audioMixer.SetFloat("", value);

    public void SetDrawing(float value) => _camera.farClipPlane = value;

    public void SetSensitivity(float value) => Debug.Log("Set Sensitivity");

    private void OnDisable() => ResetSettings();

    private void OnEnable() => ResetSettings();
}
