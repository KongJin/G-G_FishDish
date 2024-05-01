using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowWindow : MonoBehaviour, IFishPool
{
    
    [SerializeField]
    RectTransform fishWindow;

    [SerializeField]
    TMPro.TextMeshProUGUI description;
    int distInterval = 600;
    float remainMove = 0;

    float duration = 1f;
    float startTime;
    PlayableFish[] fishes;
    int curIndex;

    public void PassOver(int direction)//-1,1
    {
        int index = direction * -1;
        if(curIndex + index< 0 || curIndex + index >= fishWindow.childCount)
        {
            return;
        }
        curIndex += + index;
        remainMove +=  distInterval * direction;
        
        startTime = Time.time;
        description.text = fishes[curIndex].GetFishDescription();
    }

    void Start()
    {
        
        fishes = fishWindow.GetComponentsInChildren<PlayableFish>();
        description.text = fishes[curIndex].GetFishDescription();
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        fishWindow.localPosition = Vector3.Lerp(fishWindow.localPosition, Vector3.right * remainMove, t);
        
        
    }
    [SerializeField]
    Transform game;
    public void GameStart()
    {
        Fish _fish = Instantiate(fishes[curIndex], Vector3.zero, Quaternion.identity, transform);//

        _fish.transform.SetParent(game, false);
        _fish.transform.localPosition = Vector3.zero;
        _fish.Init((Vector3.right * GameManager.Instance.Global.screenWide*0.5f) + (Vector3.up * GameManager.Instance.Global.screenWide*0.5f), 
            this, new StandardSpec(10, _fish.GetComponent<RectTransform>()));

    }
 
    
    public Fish Get()
    {
        throw new System.NotImplementedException();
    }

    public void Release(Fish fish)
    {
        Destroy(fish);
    }
}
