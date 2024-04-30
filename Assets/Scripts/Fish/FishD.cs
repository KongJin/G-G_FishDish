using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishD : PlayableFish
{

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool UseSkill(float cooldown)
    {
        // 금붕어 스킬 구현
        return true;
    }
}
