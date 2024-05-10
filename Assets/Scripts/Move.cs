using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    public void Move(Vector3[] direction,float speed);
}


 class FishMove : IMoveAble
{
    protected RectTransform rectTransform;
    public FishMove(RectTransform _rectTransform)
    {
        rectTransform = _rectTransform;
    }

    public virtual void Move(Vector3[] direction, float speed)
    {
        rectTransform.position += direction[0] * Time.deltaTime * speed;
    }
}

class PlayerMove : FishMove
{
    public PlayerMove(RectTransform _rectTransform) : base(_rectTransform)
    {
    }
    public override void Move(Vector3[] direction, float speed)
    {
        if (direction[0].y > 0 && rectTransform.localPosition.y > Define.screenHeight)
            direction[0].y = 0;
        else if (direction[0].y < 0 && rectTransform.localPosition.y < -Define.screenHeight)
            direction[0].y = 0;

        if (direction[0].x < 0)
        {
            if (rectTransform.localPosition.x < -Define.screenWide)
                rectTransform.localPosition = new Vector3(Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
        else if (direction[0].x > 0)
        {
            if (rectTransform.localPosition.x > Define.screenWide)
                rectTransform.localPosition = new Vector3(-Define.screenWide, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
        base.Move(direction,speed );
    }
}

class Stop : IMoveAble
{
    public void Move(Vector3[] direction, float speed)
    {
        Debug.Log("얼어붙음");
    }
}