using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Sound.NowTapIndex = 0;
        GameManager.Sound.PlayBGM(GameManager.Resources.GetClip(ResourcesManager.SoundType.BGM, GameManager.Sound.NowTapIndex));
    }

}