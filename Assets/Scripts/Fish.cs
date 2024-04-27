using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    void Move(Vector3 position);
}

public interface IEatAble
{
    void Eat(int size);
}

public interface ILevelUpAble
{
    void LevelUp(int exp);
}

public class Fish : MonoBehaviour, IMoveAble, IEatAble, ILevelUpAble
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 position)
    {
        
    }

    public void Eat(int size)
    {

    }

    public void LevelUp(int exp)
    {

    }
}
