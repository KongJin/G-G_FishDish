using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager 
{
    int[] highscore;
    void SetHighScore( int score)//case 1
    {
    }

    void StartAction(Action<int[]> deligate)//case 2
    {
        deligate.Invoke(highscore);
    }


}
