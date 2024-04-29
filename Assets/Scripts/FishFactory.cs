using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IFishPool
{
    Fish Get();
    void Release(Fish fish);
}

public class FishFactory : MonoBehaviour, IFishPool
{
    int _curPoint;

    [SerializeField]
    Fish fish;

    Queue<Fish> fishQueue = new();


    public Fish Get()
    {
        Fish fish;
        if (fishQueue.TryPeek(out fish))
        {
            fish = fishQueue.Dequeue();
        }else
        {
            fish = Instantiate(this.fish, transform);
            fish.gameObject.SetActive(false);
        }
        
        return fish ;
    }


    public void Release(Fish element)
    {
        element.gameObject.SetActive(false);
        fishQueue.Enqueue(element);
    }

    // Start is called before the first frame update

    int initCount = 10;
    void Start()
    {
        
        for (int i =0; i< initCount; i++)
        {
            Fish fish = Get();
            fish.Init(initCount);
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
        
        remainTime = Random.Range(0.2f, MaxCreationInterval);
        Fish fish  =  Get();
        fish.Init(_curPoint+ initCount);
    }
}
