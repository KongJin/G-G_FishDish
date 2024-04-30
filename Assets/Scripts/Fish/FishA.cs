using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishA : PlayableFish
{
    // Start is called before the first frame update
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
