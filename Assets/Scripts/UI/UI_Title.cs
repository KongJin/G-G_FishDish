using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip clip;
    private void OnEnable()
    {
        GameManager.Sound.PlayBGM(clip);
    }

}
