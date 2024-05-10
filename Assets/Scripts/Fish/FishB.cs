using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishB : PlayableFish
{

    IEatAble temp;
    IEatAble skillEfect;
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

    
}
