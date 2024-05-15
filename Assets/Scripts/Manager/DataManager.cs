using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    int[] highScores;
    bool nowJoystick;
    public bool NowJoystick
    {
        get => nowJoystick;
        set
        {
            nowJoystick = value;
            int pos = value == true ? 1 : 0;
            PlayerPrefs.SetInt("JoyStickPos", pos);
        }
    }
    
    public int GetHighScore(int type)
    {
        return highScores[type];
    }
    int money;
    public int Money { get { return money; } }

    public DataManager()
    {
        highScores = new int[(int)Define.FishType.MAX];
        for (int i =0; i<(int)Define.FishType.MAX; i++)
        {
            string temp = PlayerPrefs.GetString($"HighScore_{i}");
            if(temp == String.Empty)
                temp = "0";
            highScores[i] = int.Parse(temp);
        }
        int.TryParse("Money", out money);

        int joystickPos = PlayerPrefs.GetInt("JoyStickPos");
        nowJoystick = joystickPos == 1;
    }
    
    public void SetHighScore(int score, int type )
    {
        if(highScores[type] < score)
        {
            highScores[type] = score;
            PlayerPrefs.SetString($"HighScore_{type}", highScores[type].ToString());
        }
        ChangeMoney(score);
    }

    public bool ChangeMoney(int variance)
    {
        if(money+ variance<0)
        {
            return false;
        }
        money += variance;
        PlayerPrefs.SetString("Money", money.ToString());
        return true;
    }

}
