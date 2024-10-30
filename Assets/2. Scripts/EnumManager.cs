using Unity.Burst.CompilerServices;

public static class EnumManager
{
    public const int SEAT = 4;
    public const int WANTED = 2;
    
    public enum SceneName
    {
        Main,
        Level,
        Game,
        Result,
        Count
    }

    public enum GameState
    {
        Playing,
        GameOver
    }

    public enum BGMAudioName
    {
        MainBGM,
        GameBGM,
        Failed,
        Death,
        Clear,
        Count
    }

    public enum SFXAudioName
    {
        Tutorial,
        GameStart,
        GameOver,
        GameClear,
        Customer,
        Bottle1,
        Bottle2,
        Bottle3,
        Liquor,
        Milk,
        Poisn,
        EasterEgg,
        Button,
        Count
    }

    
}
