using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    private ResourcesManager resourcesManager;
    [SerializeField]
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
        global = new();
        resourcesManager = new();
    }

    static void Initialize()
    {
        GameObject managers = GameObject.Find("GameManager") ?? new GameObject("GameManager");
        managers.TryGetComponent(out instance);
        DontDestroyOnLoad(instance);
    }
}
