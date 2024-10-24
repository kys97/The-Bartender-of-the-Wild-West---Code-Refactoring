using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindAnyObjectByType<GameManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            Init();
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }


    public ResourceManager GetResourceManager { get; private set; }
    public AudioManager GetAudioManager { get; private set; }

    void Init()
    {
        GetResourceManager = gameObject.AddComponent<ResourceManager>();
        GetAudioManager = gameObject.AddComponent<AudioManager>();

        GetResourceManager.Init();
        GetAudioManager.Init();
    }




    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
