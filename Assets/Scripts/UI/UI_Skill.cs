using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Skill : MonoBehaviour
{
    SkillTimer timer;
    PlayableFish fish;

    [SerializeField]
    Image skillOffImage;
    [SerializeField]
    Image skillOnImage;
    [SerializeField]
    TMPro.TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    Enchanter enchanter;


    [SerializeField]
    SkillEffecter skillEffecter;


    public void Init(PlayableFish _fish)
    {
        fish = _fish;
        timer = new CoolTime(_fish.fishData.coolTime- (enchanter.GetEnchant((int)Enchanter.EnchantType.cool,_fish.fishType) * _fish.fishData.coolUpgradeRatio), _fish.Base);
       
        skillOffImage.sprite = _fish.fishData.skillOffSprite;
        skillOnImage.sprite = _fish.fishData.skillOnSprite;
        gameObject.SetActive(true);
        SkillEffecter temp = _fish.transform.GetComponentInChildren<SkillEffecter>();
        
        if (temp == null)
            skillEffecter = Instantiate(skillEffecter, fish.transform);
        else
            skillEffecter = temp;
        skillEffecter.enabled = true;
        skillEffecter.Init(fish.fishData, fish.transform);
    }



    void Update()
    {

        timer.Running(Time.deltaTime);
        skillOnImage.fillAmount = timer.GetRatio();
        if(timer.GetRatio() <= 0)
        {
            timer = new CoolTime(fish.fishData.coolTime- (enchanter.GetEnchant((int)Enchanter.EnchantType.cool, fish.fishType) * fish.fishData.coolUpgradeRatio), fish.Base);
            skillEffecter.gameObject.SetActive(false);
            GameManager.Sound.SetSubEffect(false,0);
         
        }
        skillEffecter.SetSkill(timer.GetRatio());
        int iText = timer.GetRemainTime();

        textMeshProUGUI.text = iText == 0 ?  "": iText.ToString();
    }

    public void ClickSkill()
    {
        if (timer.GetRatio() < 1)
            return;
        float duration = fish.fishData.durationTime + (enchanter.GetEnchant((int)Enchanter.EnchantType.duration, fish.fishType) * fish.fishData.duraUpgradeRatio);
        timer = new DurationTime(duration, fish.Effect);
        skillEffecter.gameObject.SetActive(true);
        GameManager.Sound.SetSubEffect(true, duration, fish.fishData.clip);
    }

}
