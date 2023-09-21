using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Toggle soundMuteToggle;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        if (AudioListener.volume == 0 && soundMuteToggle != null)
        {
            soundMuteToggle.SetIsOnWithoutNotify(true);
        }

        if (soundMuteToggle != null)
        {
            soundMuteToggle.onValueChanged.AddListener(delegate { MuteToggle(soundMuteToggle.isOn); });
        }
    }

        public void MuteToggle(bool isMuted)
    {
        if (isMuted)
        {
            AudioListener.volume = 0;
        } else
        {
            AudioListener.volume = 1;
        }
    }
}
