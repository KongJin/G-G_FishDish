using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    [field:SerializeField]
    public FishData fishData { get; private set; }

    public SkillTimer timer { get; private set; }
    public void Init(Vector3 position,  Spec _spec)
    {
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        timer = new CoolTime(fishData.coolTime);
        gameObject.SetActive(true);
    }

    protected override void Start()
    {
        base.Start();
        GetComponent<UnityEngine.UI.Image>().sprite = fishData.fishSprite;

        Effect = SkillEffect;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
    }
    public Action Effect { get; private set; }

    protected abstract void SkillEffect();

    public override void Move(Vector3 direction)
    {
        
        if (direction.x<0)
        {
            transform.eulerAngles = Vector3.up * 180;

            if(rectTransform.localPosition.x < -Define.screenWide)
            {
                rectTransform.localPosition.Set(Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z) ;
            }
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            if (rectTransform.localPosition.x > Define.screenWide)
            {
                rectTransform.localPosition.Set(-Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
            }
        }
        base.Move(direction*spec.Speed);

    }
}
