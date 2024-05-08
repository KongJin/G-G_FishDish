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

    public void GameStart(PlayableFish _fish)
    {
        _fish = factory.Birth(_fish,joystickUI );
        skillUI.Init(_fish);
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
