using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FishFactory : MonoBehaviour
{
    int _curPoint;
    [SerializeField]
    Pool  _pool;

    // Start is called before the first frame update

    public int initCount = 10;
    void Start()
    {
        
        for (int i =0; i< initCount; i++)
        {
            Fish fish = _pool.Get();
            fish.Init(_curPoint);
        }
    }

    // Update is called once per frame
    float MaxCreationInterval = 2.0f;
    float remainTime = 0f;
    void Update()
    {
        remainTime-=Time.deltaTime;
        if(remainTime<0)
        {
            return;
        }
        
        remainTime = UnityEngine.Random.Range(0.2f, MaxCreationInterval);
        Fish fish  =  _pool.Get();
        fish.Init(_curPoint);
    }
}
