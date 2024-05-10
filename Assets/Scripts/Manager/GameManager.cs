using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) Initialize();
            return instance;
        }
    }
    
    private DataManager dataManager;
    private ResourcesManager resourcesManager;
    private SoundManager soundManager;
    private Define global;

    public static DataManager Data { get => Instance.dataManager; }
    public static ResourcesManager Resources { get => Instance.resourcesManager; }
    public static SoundManager Sound { get => Instance.soundManager; }
    public static Define Global { get => Instance.global; }

    private void Awake() 
    {
        Initialize();

        if (instance != null && instance != this) Destroy(gameObject);

        dataManager = new();
        resourcesManager = new();
        soundManager = new();
        global = new();
    }

    static void Initialize()
    {
        GameObject managers = GameObject.Find("GameManager") ?? new GameObject("GameManager");
        managers.TryGetComponent(out instance);
        DontDestroyOnLoad(instance);
    }
}
