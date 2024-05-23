using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOver : UI_Puase
{
    [SerializeField]
    TMPro.TextMeshProUGUI cur;
    [SerializeField]
    TMPro.TextMeshProUGUI high;

    [SerializeField]
    UnityEngine.UI.Image dieImage;

    public void ShowGameOver(int _cur, int _high, Sprite sprite)
    {
        cur.text = _cur.ToString("N0");
        high.text = _high.ToString("N0");
        dieImage.sprite = sprite;
        dieImage.SetNativeSize();

        gameObject.SetActive(true);
    }
    
}
