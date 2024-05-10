using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FishA : PlayableFish
{
    IMoveAble mTemp;
    IMoveAble skillEfect;

    IEatAble eTemp;
    IEatAble skillEfect2;

    protected override void Start()
    {
        base.Start();
        mTemp = mover;
        eTemp = eater;
        skillEfect = new Stop();
        skillEfect2 = EaterMaker.GetEater(Define.FishType.GOLD, this); 
    }
    protected override void SkillEffect()
    {
        mover = skillEfect;
        eater = skillEfect2;
    }

    protected override void BaseEffect()
    {
        mover = mTemp;
        eater = eTemp;
    }
}
