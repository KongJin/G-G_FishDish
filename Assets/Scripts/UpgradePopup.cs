using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enchanter;

public class UpgradePopup : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image[] img;
    [SerializeField]
    TMPro.TextMeshProUGUI[] levels;

    [SerializeField]
    TMPro.TextMeshProUGUI textMeshPro;

    [SerializeField]
    UnityEngine.UI.Button confirm;

    [SerializeField]
    TMPro.TextMeshProUGUI costTMP;
    public void SetPopup(int upgradeType, FishData data, int level, int cost)
    {
        Sprite temp;
        if (upgradeType == (int)EnchantType.cool)
        {
            temp = data.skillOffSprite;
            textMeshPro.text = $"스킬의 쿨타임이 {level * data.coolUpgradeRatio}초" + (level < Define.maxUpgrade ? $"-> {(level + 1) * data.coolUpgradeRatio}초" : "") + " 감소 합니다.";
        }
        else
        {
            temp = data.skillOnSprite;
            textMeshPro.text = $"스킬의 지속시간이 {level * data.duraUpgradeRatio}초" + (level < Define.maxUpgrade ? $"-> {(level + 1) * data.duraUpgradeRatio}초" : "") + " 증가 합니다.";

        }
        for (int i = 0; i < 2; i++)
        {
            img[i].sprite = data.skillOnSprite;
            levels[i].text = $"Level {level+1 + i}";

            if (level+i>=Define.maxUpgrade)
            {
                levels[i].text = $"MAX";
            }
        }
        costTMP.text = $"비용 : {cost}";
        costTMP.gameObject.SetActive(level < Define.maxUpgrade);
        confirm.gameObject.SetActive(level < Define.maxUpgrade);
        gameObject.SetActive(true);
    }
}
