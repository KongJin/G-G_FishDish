using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowWindow : MonoBehaviour
{
    
    [SerializeField]
    RectTransform fishWindow;


    [SerializeField]
    TextMeshProUGUI fishName;

    [SerializeField]
    TextMeshProUGUI description;

    [SerializeField]
    TextMeshProUGUI fishSkillName;

    int distInterval = 600;
    float remainMove = 0;

    float duration = 1f;
    float startTime;
    [SerializeField]
    PlayableFish[] fishes;
    int curIndex;

    [SerializeField]
    TextMeshProUGUI highScore;

   

    [SerializeField]
    GameObject blind;
    [SerializeField]
    TextMeshProUGUI blindText;

    [SerializeField]
    Enchanter enchanter;
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
        int liftingScore = fishes[curIndex].fishData.liftingScore;
        for (int i =0;i < curIndex; i++)
        {
            if(liftingScore > GameManager.Data.GetHighScore(i))
            {
                blind.SetActive(true);
                blindText.text = $"앞에 있는 모든 물고기들의\n최고점수 {fishes[curIndex].fishData.liftingScore}점 이상";
                return;
            }
        }
        blind.SetActive(false);

        highScore.text = GameManager.Data.GetHighScore(curIndex).ToString();
        fishName.text = fishes[curIndex].fishData.fishName;
        description.text = fishes[curIndex].fishData.fishDescription;
        fishSkillName.text = fishes[curIndex].fishData.fishSkillName;
        
        enchanter.SetFish( fishes[curIndex]);

    }

    void OnEnable()
    {
        PassOver(0);
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
