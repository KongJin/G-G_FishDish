using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishB : PlayableFish
{

    IEatAble temp;
    IEatAble skillEfect;

    public override int fishType => (int)Define.FishType.NEON;
    protected override void Start()
    {
        base.Start();
        temp = eater;
        skillEfect = EaterMaker.GetEater(Define.FishType.NEON,this);
    }

    protected override void BaseEffect()
    {
        eater = temp; 
    }

    protected override void SkillEffect()
    {
        eater = skillEfect;
    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 획득하는 점수가 2배가 됩니다 ( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }
}
