using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    [SerializeField]
    FishData fishData;
    public string GetFishName() { return fishData.name; }
    public string GetFishDescription() { return fishData.fishDescription; }
    
    protected SkillTimer timer;

    protected override void Start()
    {
        base.Start();
        GetComponent<UnityEngine.UI.Image>().sprite = fishData.sprite;
        timer = new CoolTime(fishData.coolTime, fishData.durationTime,SkillEffect);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer.Running(Time.deltaTime);   
    }


    protected abstract void SkillEffect();

}
