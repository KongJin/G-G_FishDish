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
    
    private DataManager dataManager = new ();
    private ResourcesManager resourcesManager = new();
    private SoundManager soundManager = new();
    private Common global = new();

    public DataManager Data { get { return dataManager; } }
    public ResourcesManager Resources { get { return resourcesManager; } }
    public SoundManager Sound { get { return soundManager; } }

    public Common Global { get { return global; } }

}
