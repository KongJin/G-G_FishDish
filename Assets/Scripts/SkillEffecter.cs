using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mesh;

public class SkillEffecter : MonoBehaviour
{
    [SerializeField]
    Slider skillDuration;
    [SerializeField]
    Image skillSpriteImage;
    [SerializeField]
    Image skillAnimImage;



    float interval = 0.05f;
    float curInterval = 0;
    int curAnimIndex;
    FishData fishData;

    Transform fishTransform;
    Transform barTransfrom;
    public void Init(FishData _fishData, Transform _fishTransform)
    {
        fishTransform = _fishTransform;
        barTransfrom= skillDuration.GetComponent<Transform>();


        fishData = _fishData;
        skillSpriteImage.sprite = fishData.skillEffectSprite;
        skillAnimImage.sprite = fishData.skillEffectAnim[0];

        skillAnimImage.SetNativeSize();
        skillSpriteImage.SetNativeSize();

        transform.localPosition = fishData.skillpos;
        gameObject.SetActive(false);
    }

    public void SetSkill(float ratio)
    {
        curInterval += Time.deltaTime;
        if (interval < curInterval)
        {
            curInterval = 0;
            skillAnimImage.sprite = fishData.skillEffectAnim[curAnimIndex++ % fishData.skillEffectAnim.Length];
        }
        skillDuration.value = ratio;
        barTransfrom.localRotation = fishTransform.localRotation;
    }
}
