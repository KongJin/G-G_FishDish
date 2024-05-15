using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    FishFactory factory;
    [SerializeField]
    UI_Skill skillUI;
    [SerializeField]
    UI_Joystick joystickUI;
    PlayableFish fish;
    
    public void GameStart(PlayableFish _fish = null)
    {
        fish = factory.Birth(_fish?_fish:fish,joystickUI );
        skillUI.Init(fish);
        
    }
    private void OnEnable()
    {
        GameManager.Sound.NowTapIndex = 1;
        GameManager.Sound.PlayBGM(GameManager.Resources.GetClip(ResourcesManager.SoundType.BGM, GameManager.Sound.NowTapIndex));
    }
}
