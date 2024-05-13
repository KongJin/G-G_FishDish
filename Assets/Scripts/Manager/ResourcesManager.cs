using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    AudioClip[][] Clips;
    
    public ResourcesManager()
    {
        Clips = new AudioClip[(int)SoundType.Max][];
        Clips[(int)SoundType.BGM] = Resources.LoadAll<AudioClip>("Sounds/BGM");
        Clips[(int)SoundType.Effect] = Resources.LoadAll<AudioClip>("Sounds/Effect");
    }

    public enum SoundType
    {
        BGM,
        SubBGM,
        Effect,
        Max,
    }

    public enum BGMClip
    {
        latale,
        maple,
        Max,
    }

    public enum EffectClip
    {
        blop,
        button,
        buy,
        gulp,
        nomnom,
        pop,
        Max,
    }

    public AudioClip GetClip(SoundType type, int index)
    {
        if (Clips[(int)type][index]==null)
        {
            Debug.Log($"AudioClip GetClip : null type = {type}, index = {index}");
        }
        return Clips[(int)type][index];
    }
}
