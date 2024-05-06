using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "FishData")]
public class FishData : ScriptableObject
{
    [field:SerializeField] public string fishName { get; private set; }
    [field: SerializeField] public string fishDescription { get; private set; }
    [field: SerializeField] public float coolTime { get; private set; }
    [field: SerializeField] public float durationTime { get; private set; }
    [field: SerializeField] public Sprite fishSprite { get; private set; }
    [field: SerializeField] public Sprite skillOnSprite { get; private set; }
    [field: SerializeField] public Sprite skillOffSprite { get; private set; }

}