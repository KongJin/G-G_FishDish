﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
interface ITimer
{
    public float GetRatio();
    public void Running(float deltaTime);
}

abstract public class SkillTimer:ITimer
{
    protected float targetTime;
    protected float curTime;
    public float GetRatio()
    {
        return curTime / targetTime;
    }
    public abstract int GetRemainTime();

    public abstract void Running(float deltaTime);

    protected SkillTimer( float _targetTime)
    {
        targetTime = _targetTime;
    }
}

class CoolTime : SkillTimer
{

    protected Action skillEffect;
    public CoolTime( float _targetTime) : base( _targetTime)
    {
        curTime = 0;
    }
    public override int GetRemainTime()
    {
        if (targetTime - curTime <= 0)
        {
            return 0;
        }
        return (int)(targetTime+1 - curTime);
    }
    public override void Running(float deltaTime)
    {
        if (curTime >= targetTime)
        {
            curTime = targetTime;
            return;
        }
        curTime += deltaTime;
    }

}

class DurationTime : SkillTimer
{
    Action skillEffect;
    public DurationTime( float _targetTime, Action _skillEffect) : base( _targetTime)
    {
        skillEffect = _skillEffect;
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
    public override void Running(float deltaTime)
    {
        if (curTime <= 0)
        {
            curTime = 0;
            return;
        }
        curTime -= deltaTime;
        skillEffect();
    }

}