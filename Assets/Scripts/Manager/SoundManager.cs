using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager:MonoBehaviour
{
    private AudioSource[] BGMSource;
    private void Awake()
    {
        BGMSource = new AudioSource[2];
        for(int i = 0; i < BGMSource.Length; i++)
        {

            BGMSource[i] = gameObject.AddComponent<AudioSource>();
            BGMSource[i].volume = 0.5f;
            BGMSource[i].loop = true;
        }
    }

    private int change;
    public void PlayBGM(AudioClip clip)
    {
        StartCoroutine(Fade(BGMSource[change], 2, 0));
        change = (change + 1) % 2;

        BGMSource[change].clip = clip;
        BGMSource[change].Play();
        StartCoroutine(Fade(BGMSource[change], 3, 0.8f));
    }

    IEnumerator Fade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }

    [SerializeField]
    private AudioSource EffectSource;
    public void PlayEffect(AudioClip clip)
    {
        // EffectSource.clip = clip;
        EffectSource.PlayOneShot(clip);
    }
    
    // public SFX sfxPlayer;
    // public BGM bgmPlayer;

    // bool isSFXMuted;
    // public bool IsSFXMuted
    // {
    //     get
    //     {
    //         int muted = PlayerPrefs.GetInt("SFXOption");
    //         isSFXMuted = muted == 1;
    //         return isSFXMuted;
    //     }
    //     set
    //     {
    //         isSFXMuted = value;
    //         int muted = value == true ? 1 : 0;
    //         PlayerPrefs.SetInt("SFXOption", muted);
    //     }
    // }

    // bool isBGMMuted;
    // public bool IsBGMMuted
    // {
    //     get
    //     {
    //         int muted = PlayerPrefs.GetInt("BGMOption");
    //         isSFXMuted = muted == 1;
    //         return isSFXMuted;
    //     }
    //     set
    //     {
    //         isSFXMuted = value;
    //         int muted = value == true ? 1 : 0;
    //         PlayerPrefs.SetInt("BGMOption", muted);
    //     }
    // }

    // public SoundManager()
    // {
    //     sfxPlayer = GameManager.Instance.GetComponentInChildren<SFX>();
    //     bgmPlayer = GameManager.Instance.GetComponentInChildren<BGM>();

    //     sfxPlayer.Initialize();
    //     bgmPlayer.Initialize();
    // }
}
