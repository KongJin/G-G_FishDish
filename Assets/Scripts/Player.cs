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
    [SerializeField]
    ShowWindow showWindow;
    

    public void GameStart( )
    {

        PlayableFish fish = factory.Birth(showWindow.GetSelectedFish(),joystickUI );

        skillUI.Init(fish);
        
    }

    private void OnEnable()
    {
        GameManager.Sound.NowTapIndex = 1;
        GameManager.Sound.PlayBGM(GameManager.Resources.GetClip(ResourcesManager.SoundType.BGM, GameManager.Sound.NowTapIndex));
        JoyStickPos();
    }
    Vector3 changePos = new Vector3(0,125,0);


    public void JoyStickPos()
    {
        RectTransform skillPos = skillUI.gameObject.GetComponent<RectTransform>();
        RectTransform joystickPos = joystickUI.gameObject.GetComponent<RectTransform>();

        if (GameManager.Data.NowJoystick == true) // true = 조이스틱 오른쪽, false = 왼쪽이 되어야합니다.
        {
            skillPos.anchorMin = Vector2.zero;
            skillPos.anchorMax = Vector2.zero;

            joystickPos.anchorMin = Vector2.right;
            joystickPos.anchorMax = Vector2.right;

            changePos.x =-125f;
            joystickPos.anchoredPosition = changePos;
            changePos.x = 125f;
            skillPos.anchoredPosition = changePos;
        }
        else
        {
            skillPos.anchorMin = Vector2.right;
            skillPos.anchorMax = Vector2.right;

            joystickPos.anchorMin = Vector2.zero;
            joystickPos.anchorMax = Vector2.zero;

            changePos.x = 125.0f;
            joystickPos.anchoredPosition = changePos;
            changePos.x = -125.0f;
            skillPos.anchoredPosition = changePos;
        }
    }
}
