using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;
class Enchanter:MonoBehaviour
{
    public enum EnchantType
    {
        cool,
        duration,
        MAX
    }

    [SerializeField]
    TextMeshProUGUI Money;

    int[][] enchantLevels;
    public int GetEnchant(int enchantType, int fishType)
    {
        return enchantLevels[enchantType][fishType];
    }
    private void Enchant()
    {
        enchantLevels[enchantType][fish.fishType]++;
        PlayerPrefs.SetInt($"Enchant_{enchantType}_{fish.fishType}", enchantLevels[enchantType][fish.fishType]);
    }

    private void Awake()
    {

        enchantLevels = new int[(int)EnchantType.MAX][];
        for (int i = 0; i < (int)EnchantType.MAX; i++)
        {
            enchantLevels[i] = new int[(int)FishType.MAX];
            for (int j = 0; j < (int)FishType.MAX; j++)
            {
                enchantLevels[i][j] = PlayerPrefs.GetInt($"Enchant_{i}_{j}");
            }
        }
        upgradeCost = new int[11] { 50, 100, 150,200,300,450,650,950,1400,2000,3000 };

        Money.text = GameManager.Data.Money.ToString();

    }

    [SerializeField]
    TMPro.TextMeshProUGUI[] levelTexts;
    
    [SerializeField]
    UnityEngine.UI.Image cool;

    [SerializeField]
    UnityEngine.UI.Image dura;

    [SerializeField]
    TextMeshProUGUI fishSkillDescription;
    PlayableFish fish;
    public void SetFish(PlayableFish _fish)
    {
        fish = _fish;
        for(int i = 0; i < (int)EnchantType.MAX;i++ )
        {
            int level = enchantLevels[i][fish.fishType];

            string temp= "Level ";
            temp += level == maxUpgrade ? "MAX" : level + 1;

            levelTexts[i].text = temp;
        }
        Money.text = GameManager.Data.Money.ToString();
        cool.sprite = fish.fishData.skillOffSprite;
        dura.sprite = fish.fishData.skillOnSprite;

        fishSkillDescription.text = _fish.GetDescription(GetEnchant(0, fish.fishType), GetEnchant(1, fish.fishType));

    }
    int[] upgradeCost;
    public int GetCost()
    {
        return upgradeCost[enchantLevels[enchantType][fish.fishType]];
    }
    [SerializeField]
    UpgradePopup popup;
    public void OpenPopup(int _enchantType)//EnchantType
    {
        enchantType = _enchantType;
        popup.SetPopup(_enchantType, fish.fishData, GetEnchant(_enchantType, fish.fishType),GetCost());
        
    }

    int enchantType;
    public void Upgrade(  )
    {
        if (GetCost() > GameManager.Data.Money)
            return;
        if (enchantLevels[enchantType][fish.fishType] >= maxUpgrade)
            return;

        GameManager.Data.ChangeMoney(-GetCost());

        Enchant();
        Money.text = GameManager.Data.Money.ToString();
        OpenPopup(enchantType);
        SetFish(fish);
    }


  
}