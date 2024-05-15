using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishA : PlayableFish
{

    IEatAble eTemp;
    IEatAble skillEfect2;

    public override int fishType => (int)Define.FishType.GOLD;

    protected override void Start()
    {
        base.Start();
        eTemp = eater;
        skillEfect2 = EaterMaker.GetEater(Define.FishType.GOLD, this); 
    }
    protected override void SkillEffect()
    {
        eater = skillEfect2;
    }

    protected override void BaseEffect()
    {
        eater = eTemp;
    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 무적이 됩니다 ( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }

}
