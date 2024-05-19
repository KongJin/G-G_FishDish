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
    AudioSource skillSpeaker;
    [SerializeField]
    Image skillSpriteImage;
    [SerializeField]
    Image skillAnimImage;



    float interval = 0.05f;
    float curInterval = 0;
    int curAnimIndex;
    FishData fishData;
    public void Init(FishData _fishData)
    {
        gameObject.SetActive(false);
        fishData = _fishData;
        skillSpriteImage.sprite = fishData.skillEffectSprite;
        skillAnimImage.sprite = fishData.skillEffectAnim[0]?? fishData.skillEffectSprite;

        skillAnimImage.SetNativeSize();
        skillSpriteImage.SetNativeSize();
        skillSpeaker.clip = fishData.clip;
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
    }
}
