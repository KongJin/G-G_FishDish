using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "FishData")]
public class FishData : ScriptableObject
{
    public string fishName;
    public string fishDescription;
    public float coolTime;
    public float durationTime;
    public Sprite sprite;
}