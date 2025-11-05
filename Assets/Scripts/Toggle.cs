using System;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField] private string ExposedParameter;

    private float _minVolume = -80f;
    private float _defaultVolume = 1f;
    private bool _isMuted;

    public event Action<float, string> TogglePressed;

    public void ToggleSound()
    {
        if (!_isMuted)
            MuteSound();
        else
            UnmuteSound();
    }

    private void MuteSound()
    {
        TogglePressed?.Invoke(_minVolume, ExposedParameter);
        _isMuted = true;
    }

    private void UnmuteSound()
    {
        TogglePressed?.Invoke(_defaultVolume, ExposedParameter);
        _isMuted = false;
    }
}
