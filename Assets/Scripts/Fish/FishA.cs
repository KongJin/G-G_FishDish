using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishA : PlayableFish
{
    IMoveAble temp;
   IMoveAble skillEfect;
    protected override void Start()
    {
        base.Start();
        temp = mover;
        skillEfect = new Stop();
    }
    protected override void SkillEffect()
    {
        mover = skillEfect;
    }

    protected override void BaseEffect()
    {
        mover = temp;
    }
}
