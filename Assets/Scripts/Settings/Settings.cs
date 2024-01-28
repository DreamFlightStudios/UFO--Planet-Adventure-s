using UnityEngine;

public static class Settings
{
    public static float Sensivity
    {
        get
        {
            float sensivity = PlayerPrefs.HasKey("Sensivity") ? PlayerPrefs.GetFloat("Sensivity") : 25f;
            return sensivity;
        }
        set => PlayerPrefs.SetFloat("Sensivity", value);
    }

    public static float Volume
    {
        get
        {
            float volume = PlayerPrefs.HasKey("Volume") ? PlayerPrefs.GetFloat("Volume") : 1f;
            return volume;
        }
        set => PlayerPrefs.SetFloat("Volume", value);
    }
}
