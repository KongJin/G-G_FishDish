using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    [field:SerializeField]
    public FishData fishData { get; private set; }

    public SkillTimer timer { get; private set; }

    public void Init(Vector3 position,  Spec _spec , IPointAdder _adder , UI_Joystick joystick , IFishPool _pool)
    {
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        timer = new CoolTime(fishData.coolTime,BaseEffect);
        gameObject.SetActive(true);
        Rigidbody2D rgbd= gameObject.AddComponent<Rigidbody2D>();
        rgbd.isKinematic = true;
        adder = _adder;
        pool = _pool;
        joystick.Init(transform, direction);
    }

    protected override void Start()
    {
        base.Start();
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        img.sprite = fishData.fishSprite;
        img.SetNativeSize();
        

        Effect = SkillEffect;
        Base = BaseEffect;
        myLayer = (short)Define.LayerType.Player;

        mover = new PlayerMove(rectTransform);
        eater = new PlayerFishEat(spec, adder);
    }

    // Update is called once per frame
    void Update()
    {
        if (spec == null)
            return;
        mover.Move(direction[0] * spec.speed);
    }
    public Action Effect { get; protected set; }
    public Action Base { get; protected set; }
    protected abstract void SkillEffect();

    protected abstract void BaseEffect();


    protected IPointAdder adder;
    
}
