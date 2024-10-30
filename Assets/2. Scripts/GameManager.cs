using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EnumManager;


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
            // Nothing to do
        }
        else if (scene.name == EnumManager.SceneName.Game.ToString())
        {
            // Game BGM Play
            GetAudioManager.SetBGM(EnumManager.BGMAudioName.GameBGM.ToString());

            // Game Init
            GameInit();
        }
        else if (scene.name == EnumManager.SceneName.Result.ToString())
        {

        }
    }

    void GameInit()
    {
        // Game Data Init
        Money = 0;
        for (int i=0; i < WANTED; i++)
        {
            WantedCriminals[i] = 0;
        }
        for(int i=0; i < SEAT; i++)
        {
            CustomerSeat[i] = 0;
        }

        // UI Init Action
        OnUIInit?.Invoke();

        // Game Start
        State = GameState.Playing;
    }

    #endregion

    #region Game

    public static int GameLevel = 1;
    public static GameState State = GameState.GameOver;
    public static int Money = 0;

    public int[] WantedCriminals = new int[WANTED];
    public int[] CustomerSeat = new int[SEAT];

    public static event Action OnDrinkMade;
    public static event Action<Customer> OnServeDrink; // 
    public static event Action<int> OnResultSet;


    #endregion

    #region Action & Event

    public static event Action OnUIInit;

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
