



using UnityEngine;


public abstract class Spec
{
    protected float size;
    protected float speed;
    protected RectTransform rectTransform;
    private float point;

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
        if (_point < GameManager.Instance.Global.minFloat)
            _point = GameManager.Instance.Global.minFloat;

        size = Random.Range(GameManager.Instance.Global.minFloat, _point);
        speed = Random.Range(GameManager.Instance.Global.minFloat, _point);
        rectTransform.localScale  *= size;
    }

    public RandomSpec(float _point , RectTransform rectTransform) :base(_point, rectTransform) {}
}

public class StandardSpec : Spec
{

    public override void LevelUp(float _point)
    {
        _point *= GameManager.Instance.Global.minFloat;
        if (_point < GameManager.Instance.Global.minFloat)
            _point = GameManager.Instance.Global.minFloat;
        _point += 0.5f;

        size += _point;
        speed += _point;
        rectTransform.localScale *= size;
    }

    public StandardSpec(float _point, RectTransform rectTransform) : base(_point, rectTransform) { }
}