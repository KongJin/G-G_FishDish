using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishA : PlayableFish
{

    IEatAble eTemp;
    IEatAble skillEfect2;
    [SerializeField] GameObject baseEffect;
    [SerializeField] GameObject subEffect;

    public override int fishType => (int)Define.FishType.GOLD;

    protected override void Start()
    {
        base.Start();
        eTemp = eater;
        skillEfect2 = EaterMaker.GetEater(Define.FishType.GOLD, this); 
    }
    protected override void SkillEffect()
    {
        eater = skillEfect2;
        if(baseEffect == null)
        {
            GameObject skillB = Resources.Load<GameObject>("Prefabs/FishA_BaseEffect");
            baseEffect = Instantiate(skillB, transform);
        }
        StartCoroutine(AnimateSprites(0, 5));
        if(subEffect == null)
        {
            GameObject skillS = Resources.Load<GameObject>("Prefabs/FishA_SubEffect");
            subEffect = Instantiate(skillS, transform);
        }
    }

    IEnumerator AnimateSprites(int start, int end)
    {
        int spriteCount = end - start + 1;
        float totalDuration = fishData.durationTime + fishData.duraUpgradeRatio;
        float timePerFrame = totalDuration / spriteCount;
        Image myImage = baseEffect.GetComponent<Image>();

        float elapsedTime = 0f;

        baseEffect.SetActive(true);
        while (elapsedTime < totalDuration)
        {
            for (int i = start; i <= end; i++)
            {
                myImage.sprite = fishData.skillEffect[i];
                elapsedTime += Time.deltaTime;
                yield return new WaitForSeconds(timePerFrame);
            }
        }
        baseEffect.SetActive(false);
    }

    protected override void BaseEffect()
    {
        eater = eTemp;
    }

    public override string GetDescription(float coolLevel, float duraLevel)
    {
        return $"{fishData.durationTime + duraLevel * fishData.duraUpgradeRatio}초간 무적이 됩니다 ( 쿨타임 {fishData.coolTime - coolLevel * fishData.coolUpgradeRatio}초 )";
    }

}
