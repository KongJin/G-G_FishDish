using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
interface ITimer
{
    public float GetRatio();
    public bool Running(float deltaTime);
}

abstract public class SkillTimer: ITimer
{
    protected float targetTime;
    protected float curTime;

    public float GetRatio()
    {
        return curTime / targetTime;
    }
    public abstract int GetRemainTime();

    public abstract bool Running(float deltaTime);

    protected SkillTimer( float _targetTime)
    {
        targetTime = _targetTime;
    }

    protected Action effect;
}

class CoolTime : SkillTimer
{

    public CoolTime( float _targetTime, Action _baseEffect) : base(_targetTime)
    {
        curTime = 0;
        effect = _baseEffect;
        effect();

    }
public override int GetRemainTime()
    {
        if (targetTime - curTime <= 0)
        {
            return 0;
        }
        return (int)(targetTime+1 - curTime);
    }
    public override bool Running(float deltaTime)
    {
        if (curTime >= targetTime)
        {
            curTime = targetTime;
            return false;
        }
        curTime += deltaTime;
        return false;
    }

}

class DurationTime : SkillTimer
{

    protected Image spriteImage;

    protected Image animImage;
    public DurationTime( float _targetTime, Action _skillEffect) : base( _targetTime)
    {
        effect = _skillEffect;
        curTime = _targetTime;
    }
    public override int GetRemainTime()
    {
        if(curTime<=0)
        {
            return 0;
        }
        return (int)(curTime+1);
    }
    public override bool Running(float deltaTime)
    {
        if (curTime <= 0)
        {
            curTime = 0;
            return false;
        }
        curTime -= deltaTime;
        effect();
        return true;
    }

}