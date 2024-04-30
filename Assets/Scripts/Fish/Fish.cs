using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    void Move(Vector3 direction);
}

public interface IEatAble
{
    void Eat(int size);
}


public class Fish : MonoBehaviour, IMoveAble, IEatAble
{
    protected Spec spec;
    protected Vector3 direction;
    [SerializeField]
    protected RectTransform rectTransform;
    protected IFishPool pool;

    // Start is called before the first frame update
    public void Init( Vector3 position ,IFishPool _pool, Spec _spec)
    {
        pool = _pool;
        spec = _spec;
        rectTransform.localPosition = position;
        if (position.x == GameManager.Instance.Global.screenWide)
        {
            direction =  Vector3.left ;
            transform.eulerAngles = new Vector3( 0, 180, 0 );
        }
        else if(position.x == 0)
        {
            direction = Vector3.right;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        gameObject.SetActive(true);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction);
        if(rectTransform.localPosition.x <0|| rectTransform.localPosition.x> GameManager.Instance.Global.screenWide)
            pool.Release(this);
        
    }

    public virtual void Move(Vector3 direction)
    {
        rectTransform.position += direction*Time.deltaTime;
        
    }

    public virtual void Eat(int size)
    {

    }

    
}
