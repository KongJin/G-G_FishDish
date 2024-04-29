using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : MonoBehaviour, IMoveAble, IEatAble
{
    Fish fish;
    protected float cooldown;
    protected float remainTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract bool UseSkill(float cooldown);

    public void Move(Vector3 direction)
    {
        ((IMoveAble)fish).Move(direction);
    }

    public void Eat(int size)
    {
        ((IEatAble)fish).Eat(size);
    }

    //움직임 컨트롤
}
