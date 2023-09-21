using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _pickUpCoinSound;
    [SerializeField] private AudioClip _explosionSound;
    private AudioSource _audioSource;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void CoinSound()
    {
        _audioSource.PlayOneShot(_pickUpCoinSound);
    }
    public void ExplosionSound()
    {
        _audioSource.PlayOneShot(_explosionSound);

    }


}
