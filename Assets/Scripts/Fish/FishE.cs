using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class FishE : PlayableFish
{
    Collider2D[] collisionTargets= new Collider2D[10];
    Fish target;
    Vector3[] temp = new Vector3[1] ;

    public override int fishType => (int)Define.FishType.PLATI;

    protected override void Start()
    {
        base.Start();
    }
    protected override void BaseEffect()
    {
    }

    protected override void SkillEffect()
    {
        Physics2D.OverlapCircleNonAlloc(rectTransform.position, spec.size*1.5f, collisionTargets);
        for ( int i =0; i<10; i++)
        {
            Collider2D collider = collisionTargets[i];
            if (collider == null )
                continue;

            collider.TryGetComponent(out target);
            if(target==null||target.gameObject.layer==myLayer)
                continue;

            temp[0] = target.direction[0] * -1;
            target.Move(temp, target.spec.speed);

            target = null;
            collisionTargets[i] = null;
        }

        
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
