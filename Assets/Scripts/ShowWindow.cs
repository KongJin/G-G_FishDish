using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowWindow : MonoBehaviour
{
    
    [SerializeField]
    RectTransform fishWindow;
    
    [SerializeField]
    TextMeshProUGUI description;

    [SerializeField]
    TextMeshProUGUI fishName;

    [SerializeField]
    TextMeshProUGUI fishSkill;
    int distInterval = 600;
    float remainMove = 0;

    float duration = 1f;
    float startTime;
    [SerializeField]
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

        fishName.text = fishes[curIndex].fishData.fishName;
        description.text = fishes[curIndex].fishData.fishDescription;
        fishSkill.text = fishes[curIndex].fishData.fishSkill;
    }

    void Start()
    {
        fishName.text = fishes[curIndex].fishData.fishName;
        description.text = fishes[curIndex].fishData.fishDescription;
        fishSkill.text = fishes[curIndex].fishData.fishSkill;
    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;
        fishWindow.localPosition = Vector3.Lerp(fishWindow.localPosition, Vector3.right * remainMove, t);
    }

    public void GameStart(Player player)
    {
        player.GameStart(fishes[curIndex]);
    }
}
