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
        enchantLevels[enchantType][fishType]++;
        PlayerPrefs.SetInt($"Enchant_{enchantType}_{fishType}", enchantLevels[enchantType][fishType]);
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
    FishData data;
    int fishType;
    [SerializeField]
    UnityEngine.UI.Image cool;

    [SerializeField]
    UnityEngine.UI.Image dura;


    public void SetFish(int _fishType,FishData _data)
    {
        if(_fishType<0 || _fishType>= (int) Define.FishType.MAX)
        {
            Debug.Log($"Enchanter SetFish type range over , type = {_fishType}");
            return;
        }
        fishType = _fishType;
        data = _data;
        for(int i = 0; i < (int)EnchantType.MAX;i++ )
        {
            int level = enchantLevels[i][_fishType];

            string temp= "Level ";
            temp += level == Define.maxUpgrade ? "MAX" : level + 1;

            levelTexts[i].text = temp;
        }
        Money.text = GameManager.Data.Money.ToString();
        cool.sprite = data.skillOffSprite;
        dura.sprite = data.skillOnSprite;
        
    }
    int[] upgradeCost;
    public int GetCost()
    {
        return upgradeCost[enchantLevels[enchantType][fishType]];
    }
    [SerializeField]
    UpgradePopup popup;
    public void OpenPopup(int _enchantType)//EnchantType
    {
        enchantType = _enchantType;
        popup.SetPopup(_enchantType, data, GetEnchant(_enchantType, fishType),GetCost());
        
    }

    int enchantType;
    public void Upgrade(  )
    {
        if (GetCost() > GameManager.Data.Money)
            return;
        if (enchantLevels[enchantType][fishType] >= Define.maxUpgrade)
            return;

        GameManager.Data.ChangeMoney(-GetCost());

        Enchant();
        Money.text = GameManager.Data.Money.ToString();
        OpenPopup(enchantType);
        SetFish(fishType, data);
    }


  
}