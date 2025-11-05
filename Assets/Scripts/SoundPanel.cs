using UnityEngine;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _buttonsSlider;

    private float _minimumValue = 0.0001f;
    private float _currentVolume;

    private void OnEnable()
    {
        _toggle.TogglePressed += ChangeVolume;
        _masterSlider.ValueChanged += ChangeVolume;
        _musicSlider.ValueChanged += ChangeVolume;
        _buttonsSlider.ValueChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _toggle.TogglePressed -= ChangeVolume;
        _masterSlider.ValueChanged -= ChangeVolume;
        _musicSlider.ValueChanged -= ChangeVolume;
        _buttonsSlider.ValueChanged -= ChangeVolume;
    }

    private void ChangeVolume(float value, string name)
    {
        if (value == 0) 
        {
            value = _minimumValue;
        }

        _currentVolume = Mathf.Log10(value) * 20;

        _audioMixerGroup.audioMixer.SetFloat(name, _currentVolume);
    }
}
