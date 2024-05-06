using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IFishPool
{
    Fish Get();
    void Release(Fish fish );
}

public class FishFactory : MonoBehaviour, IFishPool
{
    int _curPoint;

    [SerializeField]
    Fish fish;
    [SerializeField]
    TMPro.TextMeshProUGUI textMeshProUGUI;

    Queue<Fish> fishQueue = new();
    PlayableFish playfish;
    public PlayableFish Birth(PlayableFish _fish)
    {
        playfish = Instantiate(_fish, Vector3.zero, Quaternion.identity, transform);

        playfish.transform.SetParent(transform, false);
        playfish.Init(Vector3.zero, new StandardSpec(1, playfish.GetComponent<RectTransform>()));
        return playfish;
    }

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
        int height = Random.Range(-Define.screenHeight, Define.screenHeight);
        Vector3 position = Vector3.zero;

        if (Random.Range(0, 2) > 0)
        {
            position = (Vector3.right * Define.screenWide) + (Vector3.up * height);
        }
        else
        {
            position = (Vector3.left * Define.screenWide) + Vector3.up * height;
        }
        return position;
    }
 

    void Start()
    {
        
    }

    // Update is called once per frame
    float MaxCreationInterval = 1.5f;
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
        fish.Init( GetRandomPosition(), this, new RandomSpec(_curPoint , fish.GetComponent<RectTransform>()));
    }
}
