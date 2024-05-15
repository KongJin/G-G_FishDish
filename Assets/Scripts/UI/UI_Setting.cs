using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour
{
    // 조이스틱 좌우 좌표 저장필요
    [SerializeField] GameObject sfxOn;
    [SerializeField] GameObject sfxOff;
    [SerializeField] GameObject bgmOn;
    [SerializeField] GameObject bgmOff;
    [SerializeField] GameObject joystickLeft;
    [SerializeField] GameObject joystickRight;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Sound.IsBGMMuted)
        {
            bgmOff.SetActive(true);
            bgmOn.SetActive(false);
        }
        else
        {
            bgmOn.SetActive(true);
            bgmOff.SetActive(false);
        }

        if(GameManager.Sound.IsSFXMuted)
        {
            sfxOff.SetActive(true);
            sfxOn.SetActive(false);
        }
        else
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }

        if(GameManager.Data.NowJoystick)
        {
            joystickRight.SetActive(true);
            joystickLeft.SetActive(false);
        }
        else
        {
            joystickLeft.SetActive(true);
            joystickRight.SetActive(false);
        }

    }

    public void BgmOnButtonClick()
    {
        bgmOn.SetActive(true);
        bgmOff.SetActive(false);
        GameManager.Sound.IsBGMMuted = false;
        GameManager.Sound.PlayBGM(GameManager.Resources.GetClip(ResourcesManager.SoundType.BGM, GameManager.Sound.NowTapIndex));
    }

    public void BgmOffButtonClick()
    {
        bgmOff.SetActive(true);
        bgmOn.SetActive(false);
        GameManager.Sound.IsBGMMuted = true;
        GameManager.Sound.StopBGM();
    }
    
    public void SfxOnButtonClick()
    {
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
        GameManager.Sound.IsSFXMuted = false;
    }
    
    public void SfxOffButtonClick()
    {
        sfxOff.SetActive(true);
        sfxOn.SetActive(false);
        GameManager.Sound.IsSFXMuted = true;
    }

    public void JoyStickLeftButtonClick()
    {
        joystickLeft.SetActive(true);
        joystickRight.SetActive(false);
        GameManager.Data.NowJoystick = false;
    }

    public void JoyStickRightButtonClick()
    {
        joystickRight.SetActive(true);
        joystickLeft.SetActive(false);
        GameManager.Data.NowJoystick = true;
    }
}
