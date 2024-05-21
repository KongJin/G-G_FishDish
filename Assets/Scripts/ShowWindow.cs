using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


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

    float startTime;
    [SerializeField]
    PlayableFish[] fishes;
    int curIndex;

    [SerializeField]
    GameObject highScoreBox;

    [SerializeField]
    TextMeshProUGUI highScore;

    [SerializeField]
    Button startButton;

    [SerializeField]
    GameObject yellowLine;

    [SerializeField]
    GameObject blind;
    [SerializeField]
    TextMeshProUGUI blindText;

    [SerializeField]
    Enchanter enchanter;
    public void PassOver(int direction)//-1,1
    {
        int index = direction * -1;
       
        curIndex += index;

        if (curIndex < 0)
        {
            curIndex += fishWindow.childCount ;

            direction *= (fishWindow.childCount-1) * -1;

        }
        else if ( curIndex >= fishWindow.childCount)
        {

            direction *= (fishWindow.childCount - 1) * -1;
            curIndex -= fishWindow.childCount;

        }

        remainMove +=  distInterval * direction;

        startTime = Time.time;
        int liftingScore = fishes[curIndex].fishData.liftingScore;
        fishName.text = fishes[curIndex].fishData.fishName;
        for (int i =0;i < curIndex; i++)
        {
            if(liftingScore > GameManager.Data.GetHighScore(i))
            {
                blind.SetActive(true);
                highScoreBox.SetActive(false);
                startButton.interactable = false;
                blindText.text = $"앞에 있는 모든 물고기들의\n최고점수 {fishes[curIndex].fishData.liftingScore}점 이상";
                return;
            }
        }
        blind.SetActive(false);
        highScoreBox.SetActive(true);
        startButton.interactable = true;
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

    float duration = 1;
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        if(t< duration)
        {
            fishWindow.localPosition = Vector2.Lerp(fishWindow.localPosition, Vector2.right * remainMove, t);
            
        }
        yellowLine.SetActive(t> 0.4f);
    }

    public PlayableFish GetSelectedFish()
    {

        return fishes[curIndex];
    }
}
