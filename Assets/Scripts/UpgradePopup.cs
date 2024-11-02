using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Enchanter;

public class UpgradePopup : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    Image iconImage;

    [SerializeField]
    TextMeshProUGUI titleText;

    [SerializeField]
    TextMeshProUGUI[] levels;

    [SerializeField]
    TextMeshProUGUI[] descriptTexts;

    [SerializeField]
    Button confirm;

    [SerializeField]
    TextMeshProUGUI costTMP;

    public void SetPopup(int upgradeType, FishData data, int level, int cost)
    {
        iconImage.sprite = sprites[upgradeType];
        titleText.text = upgradeType == 0 ? "집중" : "인내";

        if (upgradeType == (int)EnchantType.cool)
        {
            descriptTexts[0].text = $"스킬의 쿨타임이 {level * data.coolUpgradeRatio}초" + " 감소 합니다.";
            descriptTexts[1].text = $"스킬의 쿨타임이 {level * data.coolUpgradeRatio}초" + (level < Define.maxUpgrade ? $"-> {(level + 1) * data.coolUpgradeRatio}초" : "") + " 감소 합니다.";
        }
        else if (upgradeType == (int)EnchantType.duration)
        {
            descriptTexts[0].text = $"스킬의 지속시간이 {level * data.duraUpgradeRatio}초" + " 증가 합니다.";
            descriptTexts[1].text = $"스킬의 지속시간이 {level * data.duraUpgradeRatio}초" + (level < Define.maxUpgrade ? $"-> {(level + 1) * data.duraUpgradeRatio}초" : "") + " 증가 합니다.";
        }
        for (int i = 0; i < 2; i++)
        {
            // sprites[i] = data.skillOnSprite;
            levels[i].text = $"Level {level+1 + i}";

            if (level+i>=Define.maxUpgrade)
            {
                levels[i].text = $"MAX";
            }
        }

        if(cost > GameManager.Data.Money)
        {
            confirm.interactable = false;
        }
        else
        {
            confirm.interactable = level < Define.maxUpgrade;
        }
        
        costTMP.text = level < Define.maxUpgrade ? $"Cost : {cost}" : " --   ";
        gameObject.SetActive(true);
    }
}
