using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    int highScore;
    int curScore; // 사망처리 후 사용
    public int HighScore { get { return highScore; } private set{} }

    public DataManager()
    {
        // PlayerPrefs.DeleteKey("HighScore");
        int.TryParse(PlayerPrefs.GetString("HighScore"), out highScore);
    }

    public void SetHighScore(int score)
    {
        curScore = score;
        PlayerPrefs.SetString("HighScore", highScore.ToString()); // 사망처리 추가시 제거
        // if(highScore < curScore)
        // {
        //     PlayerPrefs.SetString("HighScore", highScore.ToString());
        // }
    }
}
