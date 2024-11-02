using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SelectFishNum : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI selectFishNum;

    public void ChangeSelectFishNum(int fishNum)
    {
        selectFishNum.text = $"{fishNum + 1} / 5";
    }
}
