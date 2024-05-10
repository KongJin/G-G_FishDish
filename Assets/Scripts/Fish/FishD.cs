using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishD : PlayableFish
{
    IEatAble temp;
    IEatAble skillEfect;
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

    
}
