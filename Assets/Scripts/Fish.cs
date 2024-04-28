using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    void Move();
}

public interface IEatAble
{
    void Eat(int size);
}


public class Fish : MonoBehaviour, IMoveAble, IEatAble
{
    ILevelUpAble _spec;
    int _point;
    Vector3 _Direction;

    // Start is called before the first frame update
    public virtual void Init(int point )
    {
        _point = point;
        
        _spec.LevelUp(1, _point);
        int height = Random.Range(0, 780);
        if (Random.Range(0, 1) > 0)
        {
            _Direction =  Vector3.left ;
            transform.position = (Vector3.right * 320 )+(Vector3.up*height) ;
        }
        else
        {
            _Direction = Vector3.right;
            transform.position = Vector3.up * height;
        }
        gameObject.SetActive(true);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        
    }

    public void Eat(int size)
    {

    }

    
}
