using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishE : PlayableFish
{
    Collider2D[] collisionTargets= new Collider2D[10];
    Fish target;
    Vector3[] left = new Vector3[1] { Vector3.left };
    Vector3[] right= new Vector3[1] { Vector3.right };

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
        Physics2D.OverlapCircleNonAlloc(rectTransform.position, spec.size, collisionTargets);
        foreach (Collider2D collider in collisionTargets)
        {
            if (collider == null )
                continue;

            collider.TryGetComponent(out target);
            if(target==null||target.gameObject.layer==myLayer)
                continue;

            target.Move(target.direction[0].x < 0 ?  right: left, target.spec.speed);
            target = null;

        }

    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"위압감을 뿜어 {fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 주변 물고기를 도망치게하거나 멈춥니다. ( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }
}
