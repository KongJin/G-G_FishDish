

using UnityEngine;


public abstract class Spec
{
    public float size { get; protected set; }
    public float speed { get; protected set; }
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
        size =  Random.Range(Define.minFloat*_point, _point);
        speed = Random.Range(Define.minFloat* _point, Define.minFloat*_point*5);
        rectTransform.localScale  = new Vector3(1,1,1)*  size;
    }

    public RandomSpec(float _point , RectTransform rectTransform) :base(_point, rectTransform) {}
}

public class StandardSpec : Spec
{

    public override void LevelUp(float _point)
    {
        if (_point < Define.minFloat)
            _point = Define.minFloat;

        size += _point;
        speed += _point*Define.minFloat;
        rectTransform.localScale = new Vector3(1, 1, 1) *size;
    }
    
    public StandardSpec(float _point, RectTransform rectTransform) : base(_point, rectTransform) { speed = 0.7f; }
}