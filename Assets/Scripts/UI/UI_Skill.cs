using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void Init(PlayableFish _fish)
    {
        fish = _fish;
        timer = _fish.timer ;
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
            timer = new CoolTime(fish.fishData.coolTime,fish.Base);
        }
        int iText = timer.GetRemainTime();

        textMeshProUGUI.text = iText == 0 ?  "": iText.ToString();
        
    }

    public void ClickSkill()
    {
        if (timer.GetRatio() < 1)
            return;
        timer = new DurationTime(fish.fishData.durationTime, fish.Effect);
    }

}
