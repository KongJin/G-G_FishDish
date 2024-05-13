using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioClip[] bgmClips;
    [Range(0, 1f)]
    [SerializeField] float maxVolume;
    AudioSource bgmPlayer;

    public void Initialize()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
    }

    // void Start()
    // {
    //     if(GameManager.Sound.IsBGMMuted)
    //         bgmPlayer.volume = 0f;
    //     else
    //         bgmPlayer.volume = maxVolume;
    // }

    void Update()
    {
        
    }
}
