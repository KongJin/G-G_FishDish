using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : UI_Puase
{
    [SerializeField]
    TMPro.TextMeshProUGUI cur;
    [SerializeField]
    TMPro.TextMeshProUGUI high;

    public void ShowGameOver(int _cur, int _high)
    {
        cur.text = _cur.ToString();
        high.text = _high.ToString();
        gameObject.SetActive(true);
    }
    
}
