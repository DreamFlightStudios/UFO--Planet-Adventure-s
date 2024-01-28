using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider _sensivity;
    [SerializeField] private Slider _volume;

    public void ApplySettings()
    {
        Settings.Sensivity = _sensivity.value;
        Settings.Volume = _volume.value;

        ApplyVolume();
    }

    public void ResetSettings()
    {
        _sensivity.value = Settings.Sensivity;
        _volume.value = Settings.Volume;

        ApplyVolume();
    }

    private void ApplyVolume()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
            audioSource.volume = Settings.Volume;
    }

    private void OnDisable() => ResetSettings();
}
