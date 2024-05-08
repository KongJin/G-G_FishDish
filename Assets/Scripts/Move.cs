using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    public void Move(Vector3 direction);
}


 class FishMove : IMoveAble
{
    protected RectTransform rectTransform;
    public FishMove(RectTransform _rectTransform)
    {
        rectTransform = _rectTransform;
    }

    public virtual void Move(Vector3 direction)
    {
        rectTransform.position += direction * Time.deltaTime;
    }
}

class PlayerMove : FishMove
{
    public PlayerMove(RectTransform _rectTransform) : base(_rectTransform)
    {
    }
    public override void Move(Vector3 direction)
    {
        if (direction.y > 0 && rectTransform.localPosition.y > Define.screenHeight)
            direction.y = 0;
        else if (direction.y < 0 && rectTransform.localPosition.y < -Define.screenHeight)
            direction.y = 0;

        if (direction.x < 0)
        {
            if (rectTransform.localPosition.x < -Define.screenWide)
                rectTransform.localPosition = new Vector3(Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
        else if (direction.x > 0)
        {
            if (rectTransform.localPosition.x > Define.screenWide)
                rectTransform.localPosition = new Vector3(-Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
        base.Move(direction );
    }
}

class Stop : IMoveAble
{
    public void Move(Vector3 direction)
    {
        Debug.Log("얼어붙음");
    }
}