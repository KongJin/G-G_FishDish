using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DataManager dataManager;
    private ResourcesManager resourcesManager;
    private SoundManager soundManager;

    public DataManager Data { get { return dataManager; } }
    public ResourcesManager Resources { get { return resourcesManager; } }
    public SoundManager Sound { get { return soundManager; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
