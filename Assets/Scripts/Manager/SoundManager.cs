using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager:MonoBehaviour
{
    private AudioSource[] BGMSource;
    bool isSFXMuted;
    public bool IsSFXMuted
    {
        get => isSFXMuted;
        set
        {
            isSFXMuted = value;
            int muted = value == true ? 1 : 0;
            PlayerPrefs.SetInt("SFXOption", muted);
        }
    }

    bool isBGMMuted;
    public bool IsBGMMuted
    {
        get => isBGMMuted;
        set
        {
            isBGMMuted = value;
            int muted = value == true ? 1 : 0;
            PlayerPrefs.SetInt("BGMOption", muted);
        }
    }

    int nowTapIndex;
    public int NowTapIndex
    {
        get => nowTapIndex;
        set => nowTapIndex = value;
    }

    private void Awake()
    {
        // PlayerPrefs.DeleteKey("BGMOption");
        // PlayerPrefs.DeleteKey("SFXOption");

        int sfxOption = PlayerPrefs.GetInt("SFXOption");
        int bgmOption = PlayerPrefs.GetInt("BGMOption");

        isSFXMuted = sfxOption == 1;
        isBGMMuted = bgmOption == 1;

        BGMSource = new AudioSource[2];
        for(int i = 0; i < BGMSource.Length; i++)
        {
            BGMSource[i] = gameObject.AddComponent<AudioSource>();
            BGMSource[i].loop = true;

            if(isBGMMuted == true)
            {
                BGMSource[i].volume = 0.0f;
            }
            else
            {
                BGMSource[i].volume = 0.5f;
            }
        }
    }

    private int change;
    public void PlayBGM(AudioClip clip)
    {
        if(isBGMMuted == true)
        {
            BGMSource[change].volume = 0.0f;
            return;
        }

        StartCoroutine(Fade(BGMSource[change], 1f, 0));

        change = (change + 1) % 2;

        BGMSource[change].clip = clip;
        BGMSource[change].Play();
        StartCoroutine(Fade(BGMSource[change], 1.5f, 0.5f));

        SetSubEffect(false, 0);
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

    public void StopBGM()
    {
        for(int i = 0; i < BGMSource.Length; i++)
        {
            BGMSource[i].Stop();
        }
    }

    [SerializeField]
    private AudioSource EffectSource;
    public void PlayEffect(AudioClip clip)
    {
        // EffectSource.clip = clip;
        if(isSFXMuted == true)
        {
            EffectSource.volume = 0.0f;
        }
        else
        {
            EffectSource.volume = 1.0f;
        }
        EffectSource.PlayOneShot(clip);
    }

    [SerializeField]
    private AudioSource SubEffectSource;
    bool isPause=false;
    float currentTime;
    bool IsPause { get => isPause; set {
            isPause = value;
            if (isPause )
                SubEffectSource.volume = 0.0f;
            else
                SubEffectSource.volume = 1.0f;
        } }

    //isPlay 만 false주면 팝업중 잠시 멈추기, isPlay false와 duration 0이면 아에 초기화
    //isPlay 만 true주면 팝업없애고 남은소리 재생
    public void SetSubEffect(bool isPlay , float duration=-1 , AudioClip clip=null )
    {
        if (isSFXMuted == true)
        {
            SubEffectSource.volume = 0.0f;
        }
        else
        {
            SubEffectSource.volume = 1.0f;
        }
        if (isPlay)
        {
            if (clip == null )
            {
                IsPause = false;                
            }
            else
            {
                SubEffectSource.clip = clip;
                StartCoroutine(PlayAudio(duration));
            }
        }
        else if(duration < 0)
        {
            IsPause = true;    
        }else
        {
            SubEffectSource.Stop();
        }
       

    }
    private IEnumerator PlayAudio(float duration)
    {
        currentTime = duration;
        SubEffectSource.Play();
        while (currentTime > 0)
        {
            if(!IsPause)
                currentTime -= Time.deltaTime;            
            yield return null;
        }
        SubEffectSource.Stop();
        yield break;
    }

    


}
