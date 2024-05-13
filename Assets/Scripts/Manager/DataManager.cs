using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    int[] highScores;
    
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
