using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip[] sfxClips;
    [Range(0f, 1f)]
    [SerializeField] float maxVolume;
    AudioSource sfxPlayer;

    public void Initialize()
    {
        sfxPlayer = gameObject.AddComponent<AudioSource>();
        sfxPlayer.playOnAwake = false;
        sfxPlayer.loop = false;
    }

    // void Start()
    // {
    //     if(GameManager.Sound.IsSFXMuted)
    //         sfxPlayer.volume = 0f;
    //     else
    //         sfxPlayer.volume = maxVolume;
    // }
}
