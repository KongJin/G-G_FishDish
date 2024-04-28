using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager 
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
  
    private DataManager dataManager;
    private ResourcesManager resourcesManager;
    private SoundManager soundManager;

    public DataManager Data { get { return dataManager; } }
    public ResourcesManager Resources { get { return resourcesManager; } }
    public SoundManager Sound { get { return soundManager; } }

    public Common Global { get { return Global; } }

}
