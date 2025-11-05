using System;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private string ExposedParameter;

    public event Action<float, string> ValueChanged;

    public void SetValue(float value) 
    {
        ValueChanged?.Invoke(value, ExposedParameter);
    }
}
