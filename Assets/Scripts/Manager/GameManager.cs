using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager 
{
    static GameManager instance = new ();
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    public readonly DataManager dataManager = new ();
    public readonly ResourcesManager resourcesManager = new();
    public readonly SoundManager soundManager = new();
    public readonly Common global = new();


}
