using System.Collections;
using System.Collections.Generic;
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

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"위압감을 뿜어 {fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 주변 물고기를 멈춥니다. \n( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }
}
