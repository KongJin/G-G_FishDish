using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishC : PlayableFish
{
    float interval = 0.8f;
    float remain = 0;

    int space =200;


    [SerializeField]
    Sprite[] fishImgs;
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
