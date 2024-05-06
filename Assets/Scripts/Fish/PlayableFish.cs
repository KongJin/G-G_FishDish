using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    [field:SerializeField]
    public FishData fishData { get; private set; }

    public SkillTimer timer { get; private set; }

    public void Init(Vector3 position,  Spec _spec , IPointAdder _adder)
    {
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        timer = new CoolTime(fishData.coolTime);
        gameObject.SetActive(true);
        Rigidbody2D rgbd= gameObject.AddComponent<Rigidbody2D>();
        rgbd.isKinematic = true;
        adder = _adder;
    }

    protected override void Start()
    {
        base.Start();
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        img.sprite = fishData.fishSprite;
        img.SetNativeSize();
        

        Effect = SkillEffect;
        myLayer = (short)Define.LayerType.Player;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       
    }
    public Action Effect { get; private set; }

    protected abstract void SkillEffect();

    public override void Move(Vector3 direction)
    {
               
        if(direction.y > 0&&rectTransform.localPosition.y > Define.screenHeight)
                direction.y = 0;
        else if(direction.y < 0&&rectTransform.localPosition.y < -Define.screenHeight)
                direction.y = 0;
            
        base.Move(direction*spec.speed);

    }

    public void SetHeadDirection(Vector3 direction)
    {
        if (direction.x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;

            if (rectTransform.localPosition.x < -Define.screenWide)
            {
                rectTransform.localPosition = new Vector3(Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
            }
        }
        else if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
            if (rectTransform.localPosition.x > Define.screenWide)
            {
                rectTransform.localPosition = new Vector3(-Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
            }
        }
    }

    IPointAdder adder;
    public override void Eat(float size)
    {
        Debug.Log($"playable eat other={size} , me = {spec.size}");
        if (size > spec.size)//게임끝나야함
        { 

        }else
        {
            spec.LevelUp(size*Define.minFloat);
            adder.AddPoint();
        }
    }
}
