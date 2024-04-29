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
    ILevelUpAble _spec = new Spec();
    Vector3 direction;
    [SerializeField]
    RectTransform rectTransform;
    IFishPool pool;

    // Start is called before the first frame update
    public virtual void Init(int point , IFishPool _pool)
    {
        pool = _pool;

        _spec.LevelUp(1, point);
        int height = Random.Range(0, GameManager.Instance.Global.screenHeight);
        if (Random.Range(0, 2) > 0)
        {
            direction =  Vector3.left ;
           rectTransform.localPosition = (Vector3.right * GameManager.Instance.Global.screenWide )+(Vector3.up*height) ;
            transform.eulerAngles = new Vector3( 0, 180, 0 );
        }
        else
        {
            direction = Vector3.right;
           rectTransform.localPosition =  Vector3.up * height;
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
    }

    public void Move(Vector3 direction)
    {
        rectTransform.position += direction*Time.deltaTime;
        if(rectTransform.localPosition.x <0|| rectTransform.localPosition.x> GameManager.Instance.Global.screenWide)
        {
            pool.Release(this);
        }
    }

    public void Eat(int size)
    {

    }

    
}
