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

    Image skillSpriteImage;
    Image skillAnimImage;


    public void Init(PlayableFish _fish)
    {
        fish = _fish;
        timer = new CoolTime(_fish.fishData.coolTime- (enchanter.GetEnchant((int)Enchanter.EnchantType.cool,_fish.fishType) * _fish.fishData.coolUpgradeRatio), _fish.Base);
        skillOffImage.sprite = _fish.fishData.skillOffSprite;
        skillOnImage.sprite = _fish.fishData.skillOnSprite;
        gameObject.SetActive(true);

        if (skillSpriteImage!=null)
        {
            Destroy(skillSpriteImage.gameObject );
            Destroy(skillAnimImage.gameObject);
            skillSpriteImage = null;
            skillAnimImage = null;
        }

        skillSpriteImage =  Instantiate(new GameObject(), fish.transform).gameObject.AddComponent<Image>();
        skillAnimImage =  Instantiate(new GameObject(), fish.transform).gameObject.AddComponent<Image>();

        skillSpriteImage.sprite = fish.fishData.skillEffectSprite;
        skillAnimImage.sprite = fish.fishData.skillEffectAnim[0]?? fish.fishData.skillEffectSprite;
        skillAnimImage.SetNativeSize();
        skillSpriteImage.SetNativeSize();
        skillSpriteImage.gameObject.SetActive(false);
        skillAnimImage.gameObject.SetActive(false);
    }

    float interval = 0.05f;
    float curInterval = 0;
    int curAnimIndex;

    void Update()
    {
        if(timer.Running(Time.deltaTime))
        {

            skillSpriteImage.gameObject.SetActive(true);
            skillAnimImage.gameObject.SetActive(true);
            curInterval += Time.deltaTime;
            if (interval< curInterval)
            {
                curInterval = 0;
                skillAnimImage.sprite = fish.fishData.skillEffectAnim[curAnimIndex++% fish.fishData.skillEffectAnim.Length];

            }

        }
        else
        {
            skillSpriteImage.gameObject.SetActive(false);
            skillAnimImage.gameObject.SetActive(false);
        }
        
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
