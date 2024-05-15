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

    public void JoyStickPos()
    {
        RectTransform skillPos = skillUI.gameObject.GetComponent<RectTransform>();
        RectTransform joystickPos = joystickUI.gameObject.GetComponent<RectTransform>();

        if(GameManager.Data.NowJoystick == true) // true = 조이스틱 오른쪽, false = 왼쪽이 되어야합니다.
        {
            skillPos.anchorMin = Vector2.zero;
            skillPos.anchorMax = Vector2.zero;

            joystickPos.anchorMin = Vector2.right;
            joystickPos.anchorMax = Vector2.right;

            Vector3 changePos = joystickPos.localPosition;
            changePos.x += 250.0f;
            joystickPos.localPosition = changePos;

            changePos = skillPos.localPosition;
            changePos.x -= 250.0f;
            skillPos.localPosition = changePos;
        }
        else
        {
            skillPos.anchorMin = Vector2.right;
            skillPos.anchorMax = Vector2.right;

            joystickPos.anchorMin = Vector2.zero;
            joystickPos.anchorMax = Vector2.zero;

            Vector3 changePos = joystickPos.localPosition;
            changePos.x -= 250.0f;
            joystickPos.localPosition = changePos;

            changePos = skillPos.localPosition;
            changePos.x += 250.0f;
            skillPos.localPosition = changePos;
        }
        joystickUI.SetJoyStickPos();
    }
}
