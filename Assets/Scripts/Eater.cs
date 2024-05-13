using System;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public interface IEatAble
{
    public void Eat(float size);
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
                return new PlayerFishEat(fish.spec, fish.adder);
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
    public void Eat(float size)
    {
        if (size > spec.size) 
        { 
            pool.Release(fish); 
        }
    }
}

class PlayerFishEat : IEatAble
{
    Spec spec;
    IPointAdder adder;
    public PlayerFishEat(Spec _spec, IPointAdder _adder)
    {
        spec = _spec;
        adder = _adder;
    }
    public void Eat(float size)
    {
        if (size > spec.size)
        {
            adder.GameOver();
            AudioClip clip = GameManager.Resources.GetClip(ResourcesManager.SoundType.Effect, (int)ResourcesManager.EffectClip.nomnom);
            GameManager.Sound.PlayEffect(clip);
        }
        else
        {
            spec.LevelUp(size * Define.minFloat);
            adder.AddPoint(size);
            AudioClip clip = GameManager.Resources.GetClip(ResourcesManager.SoundType.Effect, (int)ResourcesManager.EffectClip.gulp);
            GameManager.Sound.PlayEffect(clip);
        }
    }
}

class DefenceEat : IEatAble
{
    Spec spec;
    IPointAdder adder;
    public DefenceEat(Spec _spec, IPointAdder _adder)
    {
        spec = _spec;
        adder = _adder;
    }
    public void Eat(float size)
    {
        if (size > spec.size)
        {

        }
        else
        {
            spec.LevelUp(size * Define.minFloat);
            adder.AddPoint(size);
        }
    }
}


class DoubleEat : IEatAble
{
    Spec spec;
    IPointAdder adder;
    public DoubleEat(Spec _spec, IPointAdder _adder)
    {
        spec = _spec;
        adder = _adder;
    }
    public void Eat(float size)
    {
        if (size > spec.size)
        {

        }
        else
        {
            spec.LevelUp(size * Define.minFloat);
            adder.AddPoint(size);
            adder.AddPoint(size);
        }
    }
}

class BigEat : IEatAble
{
    Spec spec;
    IPointAdder adder;
    public BigEat(Spec _spec, IPointAdder _adder)
    {
        spec = _spec;
        adder = _adder;
    }
    public void Eat(float size)
    {
        if (size > spec.size*1.5f)
        {

        }
        else
        {
            spec.LevelUp(size * Define.minFloat);
            adder.AddPoint(size);
        }
    }
}