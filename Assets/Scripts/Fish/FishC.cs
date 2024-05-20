using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FishC : PlayableFish
{
    float interval = 0.8f;
    float remain = 0;

    int space =200;


    [SerializeField]
    Sprite[] fishImgs;

    public override int fishType => (int)Define.FishType.CORI;

    public override string GetDescription(float coolLevel, float duraLevel)
    {//#80FF80  #FF8080
        return $"<color=#80FF80>{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초</color> 동안 가까이 있던 물고기들을 발견합니다. \n( 쿨타임 <color=#FF8080>{fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초</color> )";

    }

    protected override void BaseEffect()
    {

    }
        
    protected override void SkillEffect()
    {
        remain -= Time.deltaTime;
        if (remain > 0)
            return;

        remain = Random.Range(Define.minFloat, interval);

        Vector3 randompos = rectTransform.localPosition + new Vector3( Random.Range(-space, space), Random.Range(0, 2) == 0 ? space : -space, 0);
        Fish fish = pool.Get();
        
        fish.Init(randompos, pool, new RandomSpec(spec.size*Define.minFloat+2, fish.GetComponent<RectTransform>()), fishImgs[Random.Range(0, (int)Define.FishType.MAX)]);

    }

    
}
