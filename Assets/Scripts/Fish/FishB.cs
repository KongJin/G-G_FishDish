using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

    public override string GetCooltimeDescription(float coolLevel)
    {//#80FF80  #FF8080
        return $"{fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초";
        // return $" <color=#80FF80>{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초</color> 동안 무적이 됩니다. ( 쿨타임 <color=#FF8080>{fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초</color> )";
    }

    public override string GetDurationDescription(float duraLevel)
    {//#80FF80  #FF8080
        return $"{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초";
        // return $" <color=#80FF80>{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초</color> 동안 무적이 됩니다. ( 쿨타임 <color=#FF8080>{fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초</color> )";
    }
}
