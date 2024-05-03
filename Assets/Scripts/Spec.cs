



using UnityEngine;


public abstract class Spec
{
    protected float size;
    public float Size { get { return size; } }
    protected float speed;
    public float Speed { get { return speed; } }
    protected RectTransform rectTransform;

    public abstract void LevelUp(float _point);
    protected Spec(float _point, RectTransform _rectTransform)
    {
        rectTransform = _rectTransform;
        LevelUp(_point);
    }
}

public class RandomSpec : Spec
{
  
    public override void LevelUp( float _point)
    {
        if (_point < Define.minFloat)
            _point = Define.minFloat;

        size = Random.Range(Define.minFloat, _point* Define.minFloat);
        speed = Random.Range(Define.minFloat, _point);
        rectTransform.localScale  = new Vector3(1,1,1)* size;
    }

    public RandomSpec(float _point , RectTransform rectTransform) :base(_point, rectTransform) {}
}

public class StandardSpec : Spec
{

    public override void LevelUp(float _point)
    {
        _point *= Define.minFloat;
        if (_point < Define.minFloat)
            _point = Define.minFloat;
        _point += 0.5f;

        size += _point;
        speed += _point;
        rectTransform.localScale *= size;
    }

    public StandardSpec(float _point, RectTransform rectTransform) : base(_point, rectTransform) { }
}