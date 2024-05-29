using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        rectTransform.localEulerAngles += Vector3.back*50;

    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"<color=#80FF80>{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초</color> 동안 30% 큰 물고기까지 먹을 수 있습니다. ( 쿨타임 <color=#FF8080>{fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초</color> )";
    }
}
