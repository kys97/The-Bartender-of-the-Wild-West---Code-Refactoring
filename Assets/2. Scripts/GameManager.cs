using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton & Game Initialization
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

            // Game Initialization
            Init();

            // Scene Initialization
            SceneManager.sceneLoaded += OnSceneLoaded;
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
    #endregion

    #region Scene Initialization

    private bool isFirstLoad = true;
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == EnumManager.SceneName.Main.ToString())
        {
            // Main BGM Play
            GetAudioManager.SetBGM(EnumManager.BGMAudioName.MainBGM.ToString());
        }
        else if(scene.name == EnumManager.SceneName.Level.ToString())
        {
            
        }
        else if (scene.name == EnumManager.SceneName.Game.ToString())
        {
            // Game BGM Play
            GetAudioManager.SetBGM(EnumManager.BGMAudioName.GameBGM.ToString());
        }
        else if (scene.name == EnumManager.SceneName.Result.ToString())
        {

        }
    }

    #endregion

    void Start()
    {
        if(true)
        {
            // First Scene Load
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
            isFirstLoad = false;
        }
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
