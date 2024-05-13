
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFishPool
{
    Fish Get();
    void Release(Fish fish );
}
public interface IPointAdder
{
    public void AddPoint(float size);
    public void GameOver();
}

public class FishFactory : MonoBehaviour, IFishPool, IPointAdder
{
    [SerializeField]
    Transform pools;

    [SerializeField]
    Fish fish;
    [SerializeField]
    TMPro.TextMeshProUGUI pointUI;
    [SerializeField]
    TMPro.TextMeshProUGUI highScoreText;

    [SerializeField]
    Sprite[] fishImgs;

    Queue<Fish> fishQueue = new();
    PlayableFish obj;
    LinkedList<Fish> liveFishs = new();

    public PlayableFish Birth(PlayableFish _fish, UI_Joystick joystick)
    {
        curPoint = 0;
        AddPoint(0);
        
        while (liveFishs.First != null)
        {
            Release(liveFishs.First.Value);
        }
        PlayableFish playfish = Instantiate(_fish, Vector3.zero, Quaternion.identity, pools);

        playfish.transform.SetParent(pools, false);
        playfish.Init(Vector3.zero, new StandardSpec(0, playfish.GetComponent<RectTransform>()),this , joystick, this);

        if (obj != null)
            Destroy(obj.gameObject);
        obj = playfish;
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
            _fish = Instantiate(fish, Vector3.zero, Quaternion.identity, pools);//
            _fish.transform.SetParent(pools, false);
        }
        liveFishs.AddLast(_fish);
        return _fish ;
    }


    public void Release(Fish element)
    {
        element.gameObject.SetActive(false);
        liveFishs.Remove(element);
        fishQueue.Enqueue(element);
    }

    private Vector3 GetRandomPosition()
    {
        int height = Random.Range(-Define.screenHeight, Define.screenHeight);
        Vector3 position = Vector3.zero;

        if (Random.Range(0, 2) > 0)
        {
            position = (Vector3.right * (Define.screenWide+ Define.space)) + (Vector3.up * height);
        }
        else
        {
            position = (Vector3.left * (Define.screenWide+ Define.space)) + Vector3.up * height;
        }
        return position;
    }
 

    void Start()
    {
        highScoreText.text = GameManager.Data.HighScore.ToString();
    }

    // Update is called once per frame
    float MaxCreationInterval = 1.5f;
    float remainTime = 0f;
    void Update()
    {
        remainTime-=Time.deltaTime;
        if(remainTime>0)
            return;
        
        remainTime = Random.Range(Define.minFloat, MaxCreationInterval);
        Fish fish  =  Get();
        fish.Init( GetRandomPosition(), this, new RandomSpec(curPoint*0.03f* Define.minFloat +3, fish.GetComponent<RectTransform>()), fishImgs[Random.Range(0, (int)Define.FishType.MAX)]);
    }

    int curPoint;
    public void AddPoint(float size)
    {
        curPoint += (int)(size * 10);
        pointUI.text = curPoint.ToString();
        GameManager.Data.SetHighScore(curPoint);
        highScoreText.text = GameManager.Data.HighScore.ToString();
    }


    [SerializeField]
    UI_GameOver GameOverUI;
    public void GameOver()
    {
        GameOverUI.ShowGameOver(curPoint, GameManager.Data.HighScore);
    }
}
