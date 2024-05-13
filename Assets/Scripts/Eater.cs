using System;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public interface IEatAble
{
    public void Eat(float size, IEatAble fish);
    public void Eaten(float size);
}
class EaterMaker
{
    public static IEatAble GetEater(Fish fish )
    {
        return new FishEat(fish.spec, fish.pool, fish);
    }
    public static IEatAble GetEater(FishType type, PlayableFish fish)
    {        
        switch (type)
        {
            case FishType.GOLD:
                return new DefenceEat(fish.spec, fish.adder);
            case FishType.NEON:
                return new DoubleEat(fish.spec, fish.adder);
            case FishType.SWORD:
                return new BigEat(fish.spec, fish.adder);
            default: 
                return new PlayerFishEat(fish.spec, fish.adder,1);
        }
    }
}
class FishEat : IEatAble
{
    Spec spec;
    IFishPool pool;
    Fish fish;
    public FishEat(Spec _spec, IFishPool _pool, Fish _fish) 
    {
        spec = _spec;
        pool = _pool;
        fish = _fish;
    }
    public void Eat(float size, IEatAble fish)
    {
        fish.Eaten(spec.size);
    }

    public void Eaten(float size)
    {
        pool.Release(fish);
        AudioClip clip = GameManager.Resources.GetClip(ResourcesManager.SoundType.Effect, (int)ResourcesManager.EffectClip.gulp);
        GameManager.Sound.PlayEffect(clip);
    }
}

class PlayerFishEat : IEatAble
{
    protected Spec spec;
    protected IPointAdder adder;
    protected float ratio;
    public PlayerFishEat(Spec _spec, IPointAdder _adder, float _ratio)
    {
        spec = _spec;
        adder = _adder;
        ratio = _ratio;
    }
    public void Eat(float size, IEatAble fish)
    {
        if (size <= spec.size * ratio)
        {
            VirtualEat(size, fish);
            fish.Eaten(spec.size);
        }
    }
    public virtual void Eaten(float size)
    {
        if(size > spec.size * ratio)
        {
            adder.GameOver();
            AudioClip clip = GameManager.Resources.GetClip(ResourcesManager.SoundType.Effect, (int)ResourcesManager.EffectClip.nomnom);
            GameManager.Sound.PlayEffect(clip);
        }
    }
    protected virtual void VirtualEat(float size, IEatAble fish)
    {
        spec.LevelUp(size * minFloat);
        adder.AddPoint(size);
    }
}

class DefenceEat : PlayerFishEat
{
    public DefenceEat(Spec _spec, IPointAdder _adder) : base(_spec, _adder,1)  
    {   
    }
    public override void Eaten(float size)
    {
    }
}


class DoubleEat : PlayerFishEat
{
    public DoubleEat(Spec _spec, IPointAdder _adder) : base(_spec, _adder,1)
    {
    }
    protected override void VirtualEat(float size, IEatAble fish)
    {

        spec.LevelUp(size * minFloat);
        adder.AddPoint(size);
        adder.AddPoint(size);
    }
}

class BigEat : PlayerFishEat
{
    public BigEat(Spec _spec, IPointAdder _adder) : base(_spec, _adder,1.5f)
    {
    }
}