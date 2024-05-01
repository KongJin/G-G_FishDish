using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DG.Tweening.DOTweenAnimation;

abstract public class SkillTimer
{
    protected SkillTimer timer;
    protected float targetTime;
    protected float curTime;
    protected Action skillEffect;
    public float GetRatio()
    {
        return curTime / targetTime;
    }
    public bool Use()
    {
        if(GetRatio()>=1)
        {
            timer = new DurationTime(coolTime, duration,skillEffect);
            return true;
        }
        return false;
    }
    public abstract void Running(float deltaTime);

    protected float coolTime;
    protected float duration;

    protected SkillTimer(float _coolTime, float _duration, Action _skillEffect)
    {
        curTime = 1;
        targetTime = 1;
        coolTime = _coolTime;
        duration = _duration;
        skillEffect = _skillEffect;
    }
}

class CoolTime : SkillTimer
{
    
    public override void Running(float deltaTime)
    {
        if (curTime <= targetTime)
        {
            curTime = targetTime;
            return;
        }
        curTime += deltaTime;
       
    }

    public CoolTime(float _coolTime, float _duration, Action _skillEffect) :base(_coolTime, _duration, _skillEffect) { 
        targetTime = _coolTime;
        curTime = 0;
    }
}

class DurationTime : SkillTimer
{
    public override void Running(float deltaTime)
    {
        curTime -= deltaTime;
        skillEffect();
        if (curTime <= 0)
        {
            curTime = 0;
            timer = new CoolTime(coolTime, duration,skillEffect);
        }
    }
    public DurationTime(float _coolTime, float _duration, Action _skillEffect) : base(_coolTime, _duration, _skillEffect)
    {
        targetTime = _duration;
        curTime = _duration;
    }
}