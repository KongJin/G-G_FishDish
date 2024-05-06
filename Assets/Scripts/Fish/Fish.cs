using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    void Move(Vector3 direction);
}

public interface IEatAble
{
    void Eat(float size);
}


public class Fish : MonoBehaviour, IMoveAble, IEatAble
{
    public Spec spec { get; protected set; }
    protected Vector3 direction;
    
    protected RectTransform rectTransform;
    protected IFishPool pool;

    // Start is called before the first frame update
    public void Init( Vector3 position ,IFishPool _pool, Spec _spec)
    {
        pool = _pool;
        spec = _spec;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = position;
        if (position.x == Define.screenWide)
        {
            direction =  Vector3.left ;
            transform.eulerAngles = new Vector3( 0, 180, 0 );
        }
        else if(position.x == -Define.screenWide)
        {
            direction = Vector3.right;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        gameObject.SetActive(true);
    }

    protected virtual void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);
        if(rectTransform.localPosition.x <-Define.screenWide || rectTransform.localPosition.x> Define.screenWide)
            pool.Release(this);
        
    }

    public virtual void Move(Vector3 direction)
    {
        rectTransform.position += direction*Time.deltaTime;
        
    }

    public virtual void Eat(float size)
    {
        Debug.Log($"eat  other {size} ,me {spec.size} ");

        if (size>spec.size) { pool.Release(this); }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Eat(other.GetComponentInParent<Fish>().spec.size);
        Debug.Log("sss", other);
    }
  
}
