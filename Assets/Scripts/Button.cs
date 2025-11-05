using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound() 
    { 
        _audioSource.Play();
    }
}
