using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishD : PlayableFish
{
    IEatAble temp;
    IEatAble skillEfect;

    public override int fishType => (int)Define.FishType.SWORD;

    protected override void Start()
    {
        base.Start();
        temp = eater;
        skillEfect = EaterMaker.GetEater(Define.FishType.SWORD, this);
    }

    //범위 증가, ,  
    protected override void BaseEffect()
    {
        eater = temp;
        rectTransform.localEulerAngles =  new Vector3 (0,rectTransform.localEulerAngles.y,0);

    }

    protected override void SkillEffect()
    {
        eater = skillEfect;
        rectTransform.localEulerAngles += Vector3.back*5;
    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"꼬리를 휘둘러 {fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 50% 더큰 물고기를 섭취할수있게 됩니다. ( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }
}
