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
    int point;
    Vector3 direction;

    // Start is called before the first frame update
    public virtual void Init(int point )
    {
        this.point = point;

        _spec.LevelUp(1, this.point);
        int height = Random.Range(0, GameManager.Instance.Global.screenHeight);
        if (Random.Range(0, 1) > 0)
        {
            direction =  Vector3.left ;
            transform.position = (Vector3.right * GameManager.Instance.Global.screenWide )+(Vector3.up*height) ;
        }
        else
        {
            direction = Vector3.right;
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

    public void Move(Vector3 direction)
    {
        
    }

    public void Eat(int size)
    {

    }

    
}
