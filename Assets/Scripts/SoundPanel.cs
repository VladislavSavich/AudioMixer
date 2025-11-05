using UnityEngine;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour
{
    public static readonly string MasterVolume = nameof(MasterVolume);
    public static readonly string MusicVolume = nameof(MusicVolume);
    public static readonly string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolume = -80f;
    private float _defaultVolume = 0f;
    private float _currentVolume;
    private bool _isMuted;

    private void Start()
    {
        _isMuted = false;
    }

    public void ToggleSound()
    {
        if (!_isMuted)
            MuteSound();
        else
            UnmuteSound();
    }

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(volume, MasterVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(volume, MusicVolume);
    }

    public void ChangeEffectsVolume(float volume)
    {
        ChangeVolume(volume, EffectsVolume);
    }

    private void ChangeVolume(float value, string name)
    {
        _currentVolume = Mathf.Log10(value) * 20;

        _mixer.audioMixer.SetFloat(name, _currentVolume);
    }

    private void MuteSound() 
    {
        ChangeVolume(_minVolume, MasterVolume);
        _isMuted = true;
    }

    private void UnmuteSound()
    {
        ChangeVolume(_defaultVolume, MasterVolume);
        _isMuted = false;
    }
}
