using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

public class UI_Skill : MonoBehaviour
{
    SkillTimer timer;
    PlayableFish fish;

    [SerializeField]
    UnityEngine.UI.Image skillOffImage;
    [SerializeField]
    UnityEngine.UI.Image skillOnImage;
    [SerializeField]
    TMPro.TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    Enchanter enchanter;

    public void Init(PlayableFish _fish)
    {
        fish = _fish;
        timer = new CoolTime(_fish.fishData.coolTime- (enchanter.GetEnchant((int)Enchanter.EnchantType.cool,_fish.fishType) * _fish.fishData.coolUpgradeRatio), _fish.Base);
        skillOffImage.sprite = _fish.fishData.skillOffSprite;
        skillOnImage.sprite = _fish.fishData.skillOnSprite;
        gameObject.SetActive(true);
    }


    void Update()
    {
        timer.Running(Time.deltaTime);
        skillOnImage.fillAmount = timer.GetRatio();
        if(timer.GetRatio() <= 0)
        {
            timer = new CoolTime(fish.fishData.coolTime- (enchanter.GetEnchant((int)Enchanter.EnchantType.cool, fish.fishType) * fish.fishData.coolUpgradeRatio), fish.Base);
        }
        int iText = timer.GetRemainTime();

        textMeshProUGUI.text = iText == 0 ?  "": iText.ToString();
    }

    public void ClickSkill()
    {
        if (timer.GetRatio() < 1)
            return;
        timer = new DurationTime(fish.fishData.durationTime+(enchanter.GetEnchant((int)Enchanter.EnchantType.duration, fish.fishType) * fish.fishData.duraUpgradeRatio), fish.Effect);
    }

}
