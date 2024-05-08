using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEatAble
{
    void Eat(float size);
}


public class Fish : MonoBehaviour,  IEatAble
{
    public Spec spec { get; protected set; }
    protected Vector3[] direction = new Vector3[] { Vector3.zero };
    
    protected RectTransform rectTransform;
    protected IFishPool pool;

    // Start is called before the first frame update
    public void Init( Vector3 position ,IFishPool _pool, Spec _spec)
    {
        pool = _pool;
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        if (position.x >0)
        {
            direction[0] =  Vector3.left ;
            transform.eulerAngles = new Vector3( 0, 180, 0 );
        }
        else if(position.x <0)
        {
            direction[0] = Vector3.right;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        gameObject.SetActive(true);
    }

    protected virtual void Start()
    {
        myLayer = (short)Define.LayerType.Indegenous;
        mover = new FishMove(rectTransform);
        eater = this;
    }

    protected IMoveAble mover;
    void Update()
    {
        mover.Move(direction[0]*spec.speed);
        if(rectTransform.localPosition.x <-Define.screenWide- Define.space || rectTransform.localPosition.x> Define.screenWide+ Define.space)
            pool.Release(this);
        
    }

    protected IEatAble eater;
    public virtual void Eat(float size)
    {

        if (size>spec.size) { pool.Release(this); }
    }
    protected short myLayer;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Fish _fish = other.GetComponent<Fish>();
        if ( _fish.gameObject.layer == myLayer)
            return;
        eater.Eat(_fish.spec.size);
    }
  
}
