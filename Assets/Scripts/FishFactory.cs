using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Fish _fish;
        if (fishQueue.TryPeek(out _fish))
        {
            _fish = fishQueue.Dequeue();
        }else
        {
            _fish = Instantiate(fish, Vector3.zero, Quaternion.identity, transform);//

            _fish.transform.SetParent(transform, false);
            _fish.transform.localPosition = Vector3.zero;
        }
        
        return _fish ;
    }


    public void Release(Fish element)
    {
        element.gameObject.SetActive(false);
        fishQueue.Enqueue(element);
    }

    private Vector3 GetRandomPosition()
    {
        int height = Random.Range(-GameManager.Instance.global.screenHeight, GameManager.Instance.global.screenHeight);
        Vector3 position = Vector3.zero;

        if (Random.Range(0, 2) > 0)
        {
            position = (Vector3.right * GameManager.Instance.global.screenWide) + (Vector3.up * height);
        }
        else
        {
            position = (Vector3.left * GameManager.Instance.global.screenWide) + Vector3.up * height;
        }
        return position;
    }
 

    // Start is called before the first frame update

    int initCount = 10;
    void Start()
    {
        
        //for (int i =0; i< initCount; i++)
        //{
        //    Fish fish = Get();
        //    fish.Init( GetRandomPosition(), this, new RandomSpec(_curPoint + initCount, fish.GetComponent<RectTransform>()));
        //}
    }

    // Update is called once per frame
    float MaxCreationInterval = 2.0f;
    float remainTime = 0f;
    void Update()
    {
        remainTime-=Time.deltaTime;
        if(remainTime>0)
        {
            return;
        }
        
        remainTime = Random.Range(0.2f, MaxCreationInterval);
        Fish fish  =  Get();
        fish.Init( GetRandomPosition(), this, new RandomSpec(_curPoint + initCount, fish.GetComponent<RectTransform>()));
    }
}
