using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public interface IEatAble
{
    public void Eat(float size);
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