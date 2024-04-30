using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableFish : Fish
{
    protected float cooldown;
    protected float remainTime;
    //_point,new Vector3(GameManager.Instance.Global.screenWide*0.5f, GameManager.Instance.Global.screenHeight * 0.5f,0), _pool,new StandardSpec()


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract bool UseSkill(float cooldown);

    //움직임 컨트롤
}
