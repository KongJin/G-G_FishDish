using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    [field:SerializeField]
    public FishData fishData { get; private set; }
    public abstract int fishType { get; }


    public void Init(Vector3 position,  Spec _spec , IPointAdder _adder , UI_Joystick joystick , IFishPool _pool)
    {
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        gameObject.SetActive(true);

        Rigidbody2D rgbd= GetComponent<Rigidbody2D>();
        if( rgbd == null )
            rgbd= gameObject.AddComponent<Rigidbody2D>();
        rgbd.isKinematic = true;
        adder = _adder;
        pool = _pool;
        direction = new Vector3[] { Vector3.zero };
        joystick.Init(transform, direction);

        myLayer = (short)Define.LayerType.Player;
        Effect = SkillEffect;
        Base = BaseEffect;
    }

    protected override void Start()
    {
        base.Start();
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        img.sprite = fishData.fishSprite;
        img.SetNativeSize();
        

        gameObject.layer = myLayer = (short)Define.LayerType.Player;

        mover = new PlayerMove(rectTransform);
        eater = EaterMaker.GetEater(Define.FishType.MAX, this);
    }


    // Update is called once per frame
    void Update()
    {
        mover.Move(direction,spec.speed);

        
    }
    public Action Effect { get; protected set; }
    public Action Base { get; protected set; }
    protected abstract void SkillEffect();

    protected abstract void BaseEffect();


    public IPointAdder adder { get; protected set; }

    public abstract string GetCooltimeDescription(float coolLevel);
    public abstract string GetDurationDescription(float duraLevel);

}
