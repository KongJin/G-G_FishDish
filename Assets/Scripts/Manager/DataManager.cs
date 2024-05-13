using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    int highScore;
    
    public int HighScore { get { return highScore; } }

    public int Money { get; private set; }

    public DataManager()
    {
        // PlayerPrefs.DeleteKey("HighScore");
        int.TryParse(PlayerPrefs.GetString("HighScore"), out highScore);

    }

    public void SetHighScore(int score)
    {
        if(highScore< score)
        {
            highScore=score;
            PlayerPrefs.SetString("HighScore", highScore.ToString()); // 사망처리 추가시 제거
        }
        // if(highScore < curScore)
        // {
        //     PlayerPrefs.SetString("HighScore", highScore.ToString());
        // }
    }
    public bool ChangeMoney(int variance)
    {

        if(Money+ variance<0)
        {
            return false;
        }


        return true;
    }

}
