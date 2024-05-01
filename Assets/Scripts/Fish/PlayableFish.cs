using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{

    public FishData fishData ;

    protected SkillTimer timer;

    protected override void Start()
    {
        base.Start();
        GetComponent<UnityEngine.UI.Image>().sprite = fishData.fishSprite;
        timer = new CoolTime(fishData.coolTime, fishData.durationTime,SkillEffect);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer.Running(Time.deltaTime);   
    }


    protected abstract void SkillEffect();

}
